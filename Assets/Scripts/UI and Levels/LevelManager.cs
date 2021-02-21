using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class LevelManager : MonoBehaviour
{
    private int _levelInLock;
    [SerializeField] private Button[] _buttons;
    [SerializeField] private AudioMixerGroup _audioMixer;

    private void Start()
    {
        _levelInLock = PlayerPrefs.GetInt("levels", 1);

        for (int i = 0; i < _buttons.Length; i++)
        {
            _buttons[i].interactable = false;
        }

        for (int i = 0; i < _levelInLock; i++)
        {
            _buttons[i].interactable = true;
        }
    }

    public void LoadLevel(int levelindex)
    {
        SceneManager.LoadScene(levelindex);
    }

    public void EffectsMixer(float masterVolue)
    {
        _audioMixer.audioMixer.SetFloat("EffectsVolume", Mathf.Log10(masterVolue) * 20);
    }

    public void MusicMixer(float masterVolue)
    {
        _audioMixer.audioMixer.SetFloat("MusicVolume", Mathf.Log10(masterVolue) * 20);
    }
}
