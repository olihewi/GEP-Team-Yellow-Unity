using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : Ship
{
  [Header("Movement")] 
  public float movementSpeed = 1;
  public bool movementEnabled = true; // Could be used if enemies hit the player with a stun effect
  
  [Header("Combat")]
  public BasicProjectile projectileObject;
  public float fireRate = 4f;
  private float timeLastProjectileFired = 0;
  public int numberOfProjectiles = 1; // Could be used for power-ups
  public int score = 0;
  
  [Header("UI")]
  public UpdateUI scoreUI;
  
  private Collider2D playerCollider;
  private void Start()
  {
    playerCollider = GetComponent<Collider2D>();
  }

  public void Move(Vector2 movement)
  {
    transform.position += new Vector3(movement.x,movement.y,0) * (movementSpeed * Time.deltaTime);
  }

  public void Shoot()
  {
    float thisTime = Time.time; // Method of getting bullet cooldown without timers
    if (!(thisTime >= timeLastProjectileFired + 1/fireRate)) return; // Don't fire if the cooldown isn't over
    float playerWidth = numberOfProjectiles == 1 ? 0 : playerCollider.bounds.size.x * 0.75f;
    for (int projectile = 0; projectile < numberOfProjectiles; projectile++) // Support for multiple bullets (power-up)
    {
      Vector3 thisPosition = transform.position + new Vector3(-playerWidth/2 + projectile / (float)numberOfProjectiles * playerWidth*2,0,0);
      BasicProjectile thisProjectile = Instantiate(projectileObject, thisPosition, Quaternion.identity); // Fire Bullet
      thisProjectile.owner = this;
    }
    timeLastProjectileFired = thisTime;
  }

  public override void OnDestroyOther(Ship _other)
  {
    AddScore(_other.scoreReward);
  }
  
  public void AddScore(int _score)
  {
    score += _score;
    scoreUI.UpdateScore(score);
  }
}
