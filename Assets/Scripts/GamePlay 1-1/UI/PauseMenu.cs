using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu, sceneTransition;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Pause();
    }
    public void Pause()
    {
        Time.timeScale = 0;
        pauseMenu.GetComponent<DeveloperShowAndHide>().show = true;
    }
    public void Continue()
    {
        Time.timeScale = 1;
        pauseMenu.GetComponent<DeveloperShowAndHide>().show = false;
    }
    public void BackToMainMenu()
    {
        Time.timeScale = 1;
        sceneTransition.GetComponent<SceneTransition>().widen = true;
        sceneTransition.GetComponent<SceneTransition>().allowNext = true;
        PlayerPrefs.SetInt("NextScene", 0);
    }
    public void BackToDesktop()
    {
        Time.timeScale = 1;
        Application.Quit();
    }
    public void BackToFormerPosition()
    {
        Time.timeScale = 1;
        sceneTransition.GetComponent<SceneTransition>().widen = true;
        sceneTransition.GetComponent<SceneTransition>().allowNext = true;
        PlayerPrefs.SetInt("NextScene", 1);
    }
}
