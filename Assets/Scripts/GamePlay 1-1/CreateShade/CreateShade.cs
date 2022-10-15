using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateShade : MonoBehaviour
{
    public List<GameObject> nutList = new List<GameObject>();
    public AudioPlayerManager audioManager;
    void Update()
    {
        if(nutList.Count > 0 && Input.GetMouseButtonDown(0))
        {
            audioManager.Wind();
            Invoke(nameof(StopPlayingAudio), 1);
<<<<<<< HEAD
            nutList[0].transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
=======
            nutList[0].transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, 13, 0);
>>>>>>> 955510b55daaca062c069760c707c186e5d43ace
            nutList[0].AddComponent<Rigidbody2D>();
            nutList[0].GetComponent<Rigidbody2D>().gravityScale = 1;
            nutList[0].GetComponent<BoxCollider2D>().isTrigger = false;
            nutList.Remove(nutList[0]);
        }
    }
    void StopPlayingAudio()
    {
        if (audioManager.effect.clip != null)
            audioManager.effect.Stop();
    }
}
