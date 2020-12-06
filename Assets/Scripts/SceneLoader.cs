using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    //function to load the game scene
    public void SceneLoadGameScene()
    {

        
        SceneManager.LoadScene("gameScene");

    }

    public void SceneLoadMenu()
    {
        SceneManager.LoadScene("menuScene");
    }

    public void SceneLoadInstruction()
    {
        SceneManager.LoadScene("instructionScene");
    }

    // function to exit the application
    public void ExitGame()
    {
        Application.Quit();
    }

}
