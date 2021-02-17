using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrap : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Collider2D _fireCollider;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
            _animator.SetBool("isFire", true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _animator.SetBool("isFire", false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController controller = collision.gameObject.GetComponent<PlayerController>();
        if (controller != null)
        {
            controller.Dead();
        }
    }
}
