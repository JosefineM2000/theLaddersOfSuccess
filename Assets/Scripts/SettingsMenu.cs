using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider mSlider;

    private void Start()
    {
        float value;
        bool result = audioMixer.GetFloat("volume", out value);
        if (result)
        {
            mSlider.value = value;
        } else
        {
            mSlider.value = 0f;
        }
    }

    public void SetVolume(float volume)
    {
        Debug.Log(volume);
        audioMixer.SetFloat("volume", volume);
    }
}
