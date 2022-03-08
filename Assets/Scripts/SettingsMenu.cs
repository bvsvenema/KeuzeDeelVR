using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

//[RequireComponent(typeof(Dropdown))]
public class SettingsMenu : MonoBehaviour
{
    public TMPro.TMP_Dropdown QualityDropDown;
    public Slider volumeSlider;
    public AudioMixer audioMixer;

    void Start()
    {
        float Slider = PlayerPrefs.GetFloat("_sliderIndex", 0);
        int Quality = PlayerPrefs.GetInt("_qualityIndex", 4);
        QualityDropDown.value = Quality;
        volumeSlider.value = Slider;
    }

    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("volume", volume);
        PlayerPrefs.SetFloat("_sliderIndex", volume);
        Debug.Log(volume);
    }


    public void SetQuality(int qualityIndex)
    {

        QualitySettings.SetQualityLevel(qualityIndex);
        PlayerPrefs.SetInt("_qualityIndex", qualityIndex);

    }
}
