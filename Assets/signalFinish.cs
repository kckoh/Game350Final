using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class signalFinish : MonoBehaviour
{
    [SerializeField] GameObject menu;

    public void setMenu()
    {
        menu.SetActive(true);
    }

}
