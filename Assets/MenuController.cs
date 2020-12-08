using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class MenuController : MonoBehaviour
{
    [SerializeField] PlayableDirector timeline;
    [SerializeField] GameObject gameOver;
    [SerializeField] GameObject menu;
    [SerializeField] GameObject shop;
    [SerializeField] GameObject replay;
    
    bool isStop = false;

   
    void Update()
    {
        stop();
    }
    // Update is called once per frame
    public void ReplayGame()
    {
        PlayerController.death = false;

        gameOver.SetActive(false);
        menu.SetActive(false);
        shop.SetActive(false);
        replay.SetActive(false);
        timeline.Stop();
        timeline.Play();
    }

    public void Shop()
    {

    }

    public void stop()
    {
        if (Input.GetKey("escape"))
        {
            if (isStop)
            {
                replay.SetActive(true);
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

}
