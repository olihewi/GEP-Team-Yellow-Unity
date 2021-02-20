using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicProjectile : MonoBehaviour
{
    public string collisionTag = "Enemy";
    public float movementSpeed = 1.0f;
    public float damage = 1;

    public Ship owner;

    private void Update()
    {
        transform.position += transform.up * (movementSpeed * Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == collisionTag)
        {
            Ship hit = other.GetComponent<Ship>();
            hit.Damage(damage, owner);
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "MainCamera")
        {
            Destroy(gameObject);
        }
    }
}
