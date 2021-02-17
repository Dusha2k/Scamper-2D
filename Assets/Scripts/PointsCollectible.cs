using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsCollectible : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController controller = collision.gameObject.GetComponent<PlayerController>();

        if (controller != null)
        {
            CoinText.points += 1;
            Destroy(gameObject);
        }
    }

}
