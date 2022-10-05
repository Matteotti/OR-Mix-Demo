using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadSaveData : MonoBehaviour
{
    public GameObject player, mainCamera;
    void Awake()
    {
        player.transform.position = new Vector3 (PlayerPrefs.GetFloat("PlayerPosX"), PlayerPrefs.GetFloat("PlayerPosY"), PlayerPrefs.GetFloat("PlayerPosZ"));
        mainCamera.transform.position = new Vector3 (PlayerPrefs.GetFloat("CameraPosX"), PlayerPrefs.GetFloat("CameraPosY"), PlayerPrefs.GetFloat("CameraPosZ"));
    }
}
