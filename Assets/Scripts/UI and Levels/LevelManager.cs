using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    private int _levelInLock;
    [SerializeField] private Button[] _buttons;

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
}
