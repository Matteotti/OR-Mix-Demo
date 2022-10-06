using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosChange : MonoBehaviour
{
    public int nowIndex;
    public Vector3 playerSavePos, cameraSavePos;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (PlayerPrefs.GetInt("MaxIndex") < nowIndex)
            {
                PlayerPrefs.SetInt("MaxIndex", nowIndex);
                SaveData();
            }
            Camera.main.GetComponent<CameraMove>().enabled = true;
            Camera.main.GetComponent<CameraMove>().target = cameraSavePos;
        }
        
    }
    void SaveData()
    {
        PlayerPrefs.SetFloat("PlayerPosX", playerSavePos.x);
        PlayerPrefs.SetFloat("PlayerPosY", playerSavePos.y);
        PlayerPrefs.SetFloat("PlayerPosZ", playerSavePos.z);
        PlayerPrefs.SetFloat("CameraPosX", cameraSavePos.x);
        PlayerPrefs.SetFloat("CameraPosY", cameraSavePos.y);
        PlayerPrefs.SetFloat("CameraPosZ", cameraSavePos.z);
    }
}
