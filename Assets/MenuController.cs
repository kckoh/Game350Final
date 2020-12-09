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

    GameObject[] enemies;
    bool isStop = false;

    private void Start()
    {
         enemies = GameObject.FindGameObjectsWithTag("enemy");
    }
    void Update()
    {
        stop();
    }
    // Update is called once per frame
    public void ReplayGame()
    {
        PlayerController.death = false;
        //menu ui to set false
        gameOver.SetActive(false);
        menu.SetActive(false);
        shop.SetActive(false);
        replay.SetActive(false);

        //destroy all clones
        var clones = GameObject.FindGameObjectsWithTag("clone");
        
        foreach (var clone in clones)
            {
            if (clone.name == "GoldCoin" || clone.name == "ExplosonEnemy") { }
            else
                {
                    Destroy(clone);
                }
                
            }
        
        foreach (var enemy in enemies)
        {
            enemy.SetActive(true);
        }
        //timeline play and pause
        timeline.Stop();
        timeline.Play();
    }

    public void Shop()
    {

    }

    public void stop()
    {
        if (Input.GetKeyDown("escape"))
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
                replay.SetActive(false);
                timeline.Play();
                isStop = true;
            }
        }

    }

}
