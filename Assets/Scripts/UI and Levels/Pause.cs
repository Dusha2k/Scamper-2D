using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Pause : MonoBehaviour
{
    [SerializeField] GameObject _pause;
    [SerializeField] GameObject _joystickPanel;
    
    public void PauseOn()
    {
        _pause.SetActive(true);
        Time.timeScale = 0;
        _joystickPanel.SetActive(false);
    }

    public void PauseOff()
    {
        _pause.SetActive(false);
        _joystickPanel.SetActive(true);
        Time.timeScale = 1;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    
}
