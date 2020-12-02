using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    //var
    [SerializeField] GameObject explosion;
    Score score;
    float sinAngle = 0;
    public float speed = 60f;

    private void Start()
    {
        score = FindObjectOfType<Score>();
    }

    // move left and right
    void Update()
    {
        sinAngle = sinAngle + 0.1f; 
        float moveLeftRight = Mathf.Sin(sinAngle) * speed * Time.deltaTime + transform.localPosition.x;
        transform.localPosition = new Vector3(moveLeftRight, transform.localPosition.y, transform.localPosition.z);
    }

    private void OnParticleCollision(GameObject other)
    {
        score.addScore();
        Instantiate(explosion, transform.position, Quaternion.identity);
        explosion.SetActive(true);
        Destroy(gameObject);
    }
}
