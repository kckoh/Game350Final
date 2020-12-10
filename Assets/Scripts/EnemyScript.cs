using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    //var
    [SerializeField] GameObject explosion;
    [SerializeField] ParticleSystem beam;
    [SerializeField] GameObject coin;
    [SerializeField] GameObject shield;
    ParticleSystem.MainModule main;
    Score score;
    float sinAngle = 0;
    public float speed = 60f;
    public bool isShooting;
    public bool isShield;
    

    private void Start()
    {
        score = FindObjectOfType<Score>();
        if (isShooting)
        {
            main = beam.main;
            beam.Play();
            main.loop = true;
        }
    }




    private void OnParticleCollision(GameObject other)
    {
        
        score.addScore();
        Instantiate(explosion, transform.position, Quaternion.identity);
        
        explosion.SetActive(true);
        gameObject.SetActive(false);
       
        Instantiate(coin, transform.position, Quaternion.Euler(new Vector3(0, 50, 90)));
      
        if(isShield)
        {
            Instantiate(shield, transform.position, Quaternion.Euler(new Vector3(0, 65, 90)));
        }
    }

    public void shootPlayer()
    {
            beam.Play();
    }
}
