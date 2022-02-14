using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playSFX : MonoBehaviour
{
    public AudioSource startGame;
    public AudioSource openMenu;

    void PlayStart()
    {
        startGame.Play();
    }
    void PlayMenu()
    {
        openMenu.Play();
    }
}
