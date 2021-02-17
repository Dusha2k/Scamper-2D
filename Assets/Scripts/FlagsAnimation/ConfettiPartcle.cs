using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfettiPartcle : MonoBehaviour
{
    [SerializeField] public ParticleSystem _confettiParticle;
    
    void Start()
    {
        _confettiParticle.Stop();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            _confettiParticle.Play();
        }
    }
}
