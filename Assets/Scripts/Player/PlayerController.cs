using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static List<PlayerController> playerControllers = new List<PlayerController>(); // Used to access player controllers from anywhere in game

    [Header("Movement")] 
    public float movementSpeed = 1;
    private bool movementEnabled = true; // Could be used if enemies hit the player with a stun effect

    [Header("Combat")]
    public GameObject projectileObject;
    public float fireRate = 0.5f;
    private float timeLastProjectileFired = 0;
    public int numberOfProjectiles = 1; // Could be used for power-ups
    public int score = 0;

    [Header("UI")]
    public UpdateUI scoreUI;

    private Collider2D playerCollider;
    
    private void Start()
    {
        playerControllers.Add(this);
        playerCollider = GetComponent<Collider2D>();
    }
    private void Update()
    {
        ProcessInput();
    }
    private void ProcessInput()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
        bool shootInput = Input.GetButton("Shoot");

        if (movementEnabled)
        {
            ProcessMovement(moveInput);
        }
        if (shootInput)
        {
            Shoot();
        }
    }
    private void ProcessMovement(Vector2 moveInput)
    {
        transform.position += new Vector3(moveInput.x,moveInput.y,0) * (movementSpeed * Time.deltaTime);
    }
    private void Shoot()
    {
        float thisTime = Time.time; // Method of getting bullet cooldown without timers
        if (!(thisTime >= timeLastProjectileFired + 1/fireRate)) return; // Don't fire if the cooldown isn't over
        float playerWidth = numberOfProjectiles == 1 ? 0 : playerCollider.bounds.size.x * 0.75f;
        for (int projectile = 0; projectile < numberOfProjectiles; projectile++) // Support for multiple bullets (power-up)
        {
            Vector3 thisPosition = transform.position + new Vector3(-playerWidth/2 + projectile / (float)numberOfProjectiles * playerWidth*2,0,0);
            GameObject thisProjectile = Instantiate(projectileObject, thisPosition, Quaternion.identity); // Fire Bullet
            thisProjectile.GetComponent<BasicProjectile>().owningPlayer = this;
        }
        timeLastProjectileFired = thisTime;
    }

    public void AddScore(int _score)
    {
        score += _score;
        scoreUI.UpdateScore();
    }

    private void OnDestroy()
    {
        playerControllers.Remove(this);
    }
}
