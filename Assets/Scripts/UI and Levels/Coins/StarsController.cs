using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsController : MonoBehaviour
{
    [SerializeField] private GameObject _star1, _star2, _star3;
    public static int OpenStar1, OpenStar2, OpenStar3;
    void Start()
    {
        OpenStar1 = PlayerPrefs.GetInt("stars1", 1);
        OpenStar2 = PlayerPrefs.GetInt("stars2", 1);
        OpenStar3 = PlayerPrefs.GetInt("stars3", 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
