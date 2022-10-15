using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    public Vector3 initPlayerPos, initCameraPos;
    public Button buttonNew, buttonLoad, buttonDevelopers, buttonQuit;
    public GameObject developersInfoPanel, sceneTransition;
    public AudioPlayerManager playerManager;
    private void Start()
    {
        if(!PlayerPrefs.HasKey("IfFirstTime"))
            PlayerPrefs.SetInt("IfFirstTime", 1);
    }
    public void New()
    {
        PlayerPrefs.SetInt("IfFirstTime", 0);
        PlayerPrefs.SetInt("MaxIndexs", 1);
        PlayerPrefs.SetFloat("PlayerPosX", initPlayerPos.x);
        PlayerPrefs.SetFloat("PlayerPosY", initPlayerPos.y);
        PlayerPrefs.SetFloat("PlayerPosZ", initPlayerPos.z);
        PlayerPrefs.SetFloat("CameraPosX", initCameraPos.x);
        PlayerPrefs.SetFloat("CameraPosY", initCameraPos.y);
        PlayerPrefs.SetFloat("CameraPosZ", initCameraPos.z);
        sceneTransition.GetComponent<SceneTransition>().widen = true;
        sceneTransition.GetComponent<SceneTransition>().allowNext = true;
        PlayerPrefs.SetInt("NextScene", 1);
    }
    public void Load()
    {
        sceneTransition.GetComponent<SceneTransition>().widen = true;
        sceneTransition.GetComponent<SceneTransition>().allowNext = true;
        PlayerPrefs.SetInt("NextScene", 1);
    }
    public void Developers()
    {
        developersInfoPanel.GetComponent<DeveloperShowAndHide>().show = true;
    }
    public void Quit()
    {
        Application.Quit();
    }
}
