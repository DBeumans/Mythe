using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour {

    private ScreenFader fader;

    private int sceneIndex;

    private void Start()
    {
        fader = GetComponent<ScreenFader>();
        fader.FadeInStatus += switchLevel;
    }
    public void startLevelSwitch(int _sceneIndex)
    {
        sceneIndex = _sceneIndex;
        fader.ScreenFadeIn();
    }

    private void switchLevel()
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
