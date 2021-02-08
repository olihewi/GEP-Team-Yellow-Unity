using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicProjectile : MonoBehaviour
{
    public float movementSpeed = 1.0f;
    public int damageTotal = 100;

    private const float OutOfRange = 6.0f;

    private UpdateUI ui;

    private void Update()
    {
        transform.position += new Vector3(0, movementSpeed, 0) * Time.deltaTime;

        if(transform.position.y >= OutOfRange)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            ui.UpdateScore(damageTotal);

            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
