using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController controller = collision.gameObject.GetComponent<PlayerController>();
        if(controller != null)
        {
            controller.Dead();
        }
    }
    
}
