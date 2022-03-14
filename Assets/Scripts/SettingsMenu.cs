using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

//[RequireComponent(typeof(Dropdown))]
public class SettingsMenu : MonoBehaviour
{
    public TMPro.TMP_Dropdown QualityDropDown;
    public Slider volumeSlider;
    public AudioMixer audioMixer;
    
    static int volumes = 0;
    //public List<Button> buttons;

    void Start()
    {
        float Slider = PlayerPrefs.GetFloat("_sliderIndex", 0);
        int Quality = PlayerPrefs.GetInt("_qualityIndex", 4);
        QualityDropDown.value = Quality;
        volumeSlider.value = Slider;

    }

    private void Update()
    {
        
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

    public void MoreVolumeButton()
    {
        volumes += 10;
        volumeSlider.value += 10;
        //SetVolume(10);
        audioMixer.SetFloat("volume", volumes);
        PlayerPrefs.SetFloat("_sliderIndex", volumes);
    }

    public void LessVolumeButton()
    {
        volumes -= 10;
        volumeSlider.value -= 10;
        //SetVolume(-10);
        audioMixer.SetFloat("volume", volumes);
        PlayerPrefs.SetFloat("_sliderIndex", volumes);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("SampleScene");
    }

}
