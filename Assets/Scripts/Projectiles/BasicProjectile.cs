using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicProjectile : MonoBehaviour
{
    public float movementSpeed = 1.0f;
    public int damage = 1;

    private const float OutOfRange = 6.0f;

    public PlayerController owningPlayer;

    private void Update()
    {
        transform.position += new Vector3(0, movementSpeed, 0) * Time.deltaTime;

        if(transform.position.y >= OutOfRange)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            BasicEnemy enemy = other.GetComponent<BasicEnemy>();
            enemy.Damage(damage, owningPlayer);
            Destroy(gameObject);
        }
    }
}
