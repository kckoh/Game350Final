using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    //var
    [SerializeField] GameObject explosion;
    [SerializeField] ParticleSystem beam;
    [SerializeField] GameObject coin;
    ParticleSystem.MainModule main;
    Score score;
    float sinAngle = 0;
    public float speed = 60f;
    public bool isShooting;
    public bool isCoin;
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
        Destroy(gameObject);
        if (isCoin)
        {
            Instantiate(coin, transform.position, Quaternion.identity);
        }
        else if(isShield)
        {

        }
        
    }

    public void shootPlayer()
    {
            beam.Play();
        
    }
}
