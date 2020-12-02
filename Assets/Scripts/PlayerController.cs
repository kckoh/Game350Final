using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class PlayerController : MonoBehaviour
{

    //var
    [SerializeField] float speedX = 1f;
    [SerializeField] float xLimit = 0.5f;
    [SerializeField] float speedY = 1f;
    [SerializeField] float yLimit = 0.2f;
    [SerializeField] float horizontalX, horizontalY;
    [SerializeField] float XPosFactor = -5f;
    [SerializeField] float XControlFactor = -20f;
    [SerializeField] float YPosFactor = 5f;
    [SerializeField] float ZPosFactor = -5f;

    //canvas
    [SerializeField] GameObject explosion;
    [SerializeField] GameObject gameOver;
    [SerializeField] GameObject menu;
    [SerializeField] ParticleSystem beam;

    bool isShooting = false;
    ParticleSystem.MainModule  main;

    //to set the bullet
    private void Start()
    {
        main = beam.main;
    }
    


    // Update is called once per frame
    void Update()
    {
        translationControl();
        rotationControl();
        shootControl();
    }


   //control the translation movement
    public void translationControl()
    {
        horizontalX = CrossPlatformInputManager.GetAxis("Horizontal");
        horizontalY = CrossPlatformInputManager.GetAxis("Vertical");
      
        transform.localPosition = new Vector3(
            xClamp(horizontalX),
            yClamp(horizontalY),
            transform.localPosition.z
            );
    }

    //limit y axis
    public float yClamp (float horizontalY)
    {
        
        float yPosOffset = horizontalY * speedX * Time.deltaTime;
        float beforeClampYPos = transform.localPosition.y + yPosOffset;
        float clampYPos = Mathf.Clamp(beforeClampYPos, -yLimit, yLimit);
        return clampYPos;
    }

    public float xClamp(float horizontalX)
    {
        float xPosOffset = horizontalX * speedX * Time.deltaTime;
        float beforeClampXPos = transform.localPosition.x + xPosOffset;
        float clampXPos = Mathf.Clamp(beforeClampXPos, -xLimit, xLimit);
        return clampXPos;
    }

    public void rotationControl()
    {   
        //get location.y from the localposition
        float rotationXPos = transform.localPosition.y * XPosFactor;
        //get horizontal y
        float rotationXControl = horizontalY * XControlFactor;
        float moveToFront = 90f;
        //add to get the fell of ratation
        float rotationX = rotationXPos + rotationXControl + moveToFront;
        float rotationY = transform.localPosition.x * YPosFactor;
        float rotationZ = horizontalX *ZPosFactor;

        //rotation applied
        transform.localRotation = Quaternion.Euler(rotationX, rotationY, rotationZ);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        gameOver.SetActive(true);
        menu.SetActive(true);
        explosion.SetActive(true);

    }

    //shooting management
    private void shootControl()
    {
        //if space entered, player shoots
        if (Input.GetKeyDown("space"))
        {
            beam.Play();
            main.loop = true;
        }

        if (Input.GetKeyUp("space"))
        {
            main.loop = false;
        }
    }

}
