using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 1.0f;
    public GameObject projectileObject;

    private void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        float yInput = Input.GetAxisRaw("Vertical");
        bool shootInput = Input.GetButtonDown("Shoot");

        transform.position += new Vector3(xInput, yInput, 0) * movementSpeed * Time.deltaTime;

        if (shootInput)
        {
            Instantiate(projectileObject, transform.position, Quaternion.identity);
        }
    }
}
