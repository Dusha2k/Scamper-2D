using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTrapController : MonoBehaviour
{
    [SerializeField] private float _delay = 0.1f;
    [SerializeField] Rigidbody2D _rigidbody2d;
    [SerializeField] Collider2D _collider;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
            StartCoroutine(Falling(_delay));
        }
        
    }

    IEnumerator Falling(float _delay)
    {
        yield return new WaitForEndOfFrame();
        _rigidbody2d.isKinematic = false;
        _rigidbody2d.gravityScale = 3;
        _collider.isTrigger = true;
    }
}
