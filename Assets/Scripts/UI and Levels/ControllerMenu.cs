using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class ControllerMenu : MonoBehaviour
{
    [SerializeField] private GameObject _menuButtons;
    [SerializeField] private GameObject _levelButtons;
    [SerializeField] private GameObject _EffectsOn;
    [SerializeField] private GameObject _EffectsOff;
    [SerializeField] private GameObject _MusicOn;
    [SerializeField] private GameObject _MusicOff;
    [SerializeField] private AudioMixerGroup _audioMixer;

    public void ShowLevelButtons()
    {
        _menuButtons.SetActive(false);
        _levelButtons.SetActive(true);
    }

    public void ShowMenuButtons()
    {
        _menuButtons.SetActive(true);
        _levelButtons.SetActive(false);
    }

    public void EffectsOn()
    {
        _audioMixer.audioMixer.SetFloat("EffectsVolume", -80);
        _EffectsOn.SetActive(false);
        _EffectsOff.SetActive(true);
        
    }

    public void EffectsOff()
    {
        _audioMixer.audioMixer.SetFloat("EffectsVolume", 2);
        _EffectsOn.SetActive(true);
        _EffectsOff.SetActive(false);
    }

    public void MusicOn()
    {
        _audioMixer.audioMixer.SetFloat("MusicVolume", -80);
        _MusicOn.SetActive(false);
        _MusicOff.SetActive(true);

    }

    public void MusicOff()
    {
        _audioMixer.audioMixer.SetFloat("MusicVolume", -5);
        _MusicOn.SetActive(true);
        _MusicOff.SetActive(false);
    }

    public void QuiteTheGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        if(PlayerPrefs.GetInt("levels") <= 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + PlayerPrefs.GetInt("levels"));
        }
        
    }
}
