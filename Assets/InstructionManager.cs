using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InstructionManager : MonoBehaviour
{
    private int index = 0;
    public GameObject[] instructions;
  

    // Update is called once per frame
    void Update()
    {

        //move instruction index - 0
        if ((Input.GetKeyDown(KeyCode.LeftArrow) ||
            Input.GetKeyDown(KeyCode.RightArrow) ||
            Input.GetKeyDown(KeyCode.UpArrow) ||
            Input.GetKeyDown(KeyCode.DownArrow)) && (index == 0)
            )
        {
            StartCoroutine(instructionCoroutine(index,1));
            index++;
        }

        //shoot instruction index - 1
        if (Input.GetKeyDown(KeyCode.Space) && (index == 1))
        {
            StartCoroutine(instructionCoroutine(index,1));
            index++;
        }

        //goto menu
        if (index == 2)
        {
            StartCoroutine(instructionCoroutine(index, 3));

            
        }
        
    }

    IEnumerator instructionCoroutine(int num, int waitTime)
    {
        
        yield return new WaitForSeconds(waitTime);

        instructions[num].SetActive(false);
        instructions[num + 1].SetActive(true);
        
    }

   

}
