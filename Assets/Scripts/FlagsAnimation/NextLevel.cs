using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private AudioSource _nextLevelSound;
    private int _countOfPlay = 1;
    private float _delay = 3f;
    
    IEnumerator nextLevel(float _delay)
    {
        yield return new WaitForSeconds(_delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void UnlockLevel()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;

        if(currentLevel >= PlayerPrefs.GetInt("levels"))
        {
            PlayerPrefs.SetInt("levels", currentLevel + 1);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player") 
        {
            UnlockLevel();
            StartCoroutine(nextLevel(_delay));
            _animator.SetBool("endLevel", true);
            if(_countOfPlay > 0)
            {
                _nextLevelSound.Play();
                --_countOfPlay;
            }
        }
        
    }
}
