using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public bool widen, finish, allowNext;
    public float speed;
    void Update()
    {
        if(widen && transform.localScale.x < 30)
        {
            transform.localScale += new Vector3(speed * Time.unscaledDeltaTime, speed * Time.unscaledDeltaTime, speed * Time.unscaledDeltaTime);
            finish = false;
        }
        else if(!widen && transform.localScale.x > 0.05)
        {
            transform.localScale -= new Vector3(speed * Time.unscaledDeltaTime, speed * Time.unscaledDeltaTime, speed * Time.unscaledDeltaTime);
            finish = false;
        }
        else if(transform.localScale.x > 30)
        {
            transform.localScale = new Vector3(30, 30, 30);
            finish = true;
            if (allowNext)
                SceneManager.LoadScene(PlayerPrefs.GetInt("NextScene"));
        }
        else if(transform.localScale.x < 0.05)
        {
            transform.localScale = Vector3.zero;
            finish = true;
            if (allowNext)
                SceneManager.LoadScene(PlayerPrefs.GetInt("NextScene"));
        }
    }
}