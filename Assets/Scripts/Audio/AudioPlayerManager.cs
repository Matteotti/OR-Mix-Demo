using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayerManager : MonoBehaviour
{
    public AudioClip mainMenuBGM, gameplayBGM, fall, dead, footStep, wind;
    public AudioSource music, effect;
    public void MainMenuBGM()
    {
        music.PlayOneShot(mainMenuBGM);
    }
    public void GameplayBGM()
    {
        music.PlayOneShot(gameplayBGM);
    }
    public void Fall()
    {
        effect.PlayOneShot(fall);
    }
    public void Dead()
    {
        effect.PlayOneShot(dead);
    }
    public void FootStep()
    {
        effect.PlayOneShot(footStep);
    }
    public void Wind()
    {
        effect.PlayOneShot(wind);
    }
    public void StopFly()
    {
        effect.Stop();
    }
    public void StopWalk()
    {
        effect.Stop();
    }
}
