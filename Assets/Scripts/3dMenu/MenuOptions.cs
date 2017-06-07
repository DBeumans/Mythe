//Brian Boersen
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuOptions : MonoBehaviour
{
    public void goToMainMenu()
    {
        //This gives the obselete warning
        //Application.LoadLevel(0);

        //Unity have a new way for doing this :
        SceneManager.LoadScene(0);
    }

    public void restartGame()
    {
        Scene currScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currScene.buildIndex);
    }



}
