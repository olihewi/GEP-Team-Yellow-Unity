using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static List<PlayerController> playerControllers = new List<PlayerController>(); // Used to access player controllers from anywhere in game
    private PlayerShip ship;

    private void Start()
    {
        playerControllers.Add(this);
        ship = GetComponent<PlayerShip>();
    }
    private void Update()
    {
        ProcessInput();
    }
    private void ProcessInput()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
        bool shootInput = Input.GetButton("Shoot");

        if (ship.movementEnabled)
        {
            ship.Move(moveInput);
        }
        if (shootInput)
        {
            ship.Shoot();
        }
    }
    private void OnDestroy()
    {
        playerControllers.Remove(this);
    }
}
