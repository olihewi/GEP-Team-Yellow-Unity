using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPowerup : MonoBehaviour
{
    private PlayerShip player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerShip>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player.gameObject)
        {
            player.numberOfProjectiles++;
            Destroy(gameObject);
        }
    }
}
