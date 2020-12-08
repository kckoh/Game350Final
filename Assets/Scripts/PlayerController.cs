using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
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
    [SerializeField] PlayableDirector timeline;
    [SerializeField] GameObject shop;
    [SerializeField] GameObject replay;

    bool isShooting = true;
    static public bool death = false;
    ParticleSystem.MainModule  main;


    //Shield
    ShieldEffect shieldEffect;
    [SerializeField] GameObject shield;
    public bool isShield = false;

 

    //Shop and replay
   

    private void Start()
    {
        main = beam.main;
    }
    
    // Update is called once per frame
    void Update()
    {
        //stop moving when dead
        if (!death)
        {
            translationControl();
            rotationControl();
            shootControl();
        }
        //stop();
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
        if(other.name == "GoldCoin")
        {
            Debug.Log("detecting : " + other.name);
            
        }

        else if(other.name == "ShieldPickup")
        {
            Debug.Log("detecting : " + other.name);
            shield.SetActive(true);
            StartCoroutine(ShieldDisappearCoroutine());
        }

        else
        {
            if (isShield){}
            else
            {
                //Destroy(gameObject);
                death = true;
                gameOver.SetActive(true);
                menu.SetActive(true);
                shop.SetActive(true);
                replay.SetActive(true);
                explosion.SetActive(true);
            }
        }
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

    IEnumerator ShieldDisappearCoroutine()
    {

        isShield = true;
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(10);
        shield.SetActive(false);
        isShield = false;

        //After we have waited 5 seconds print the time again.

    }

  /*  public void stop()
    {
        if (Input.GetKey("escape"))
        {
            if (isStop)
            {
                menu.SetActive(true);
                shop.SetActive(true);
                timeline.Pause();
                isStop = false;
            }
            else
            {
                menu.SetActive(false);
                shop.SetActive(false);
                timeline.Play();
                isStop = true;
            }
            
            
        }

    }
*/

}
