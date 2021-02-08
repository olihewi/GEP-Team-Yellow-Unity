using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
  public int healthPoints = 1;
  public int scoreReward = 1;

  public void Damage(int _damage, PlayerController _player)
  {
    healthPoints -= _damage;
    if (healthPoints <= 0)
    {
      _player.AddScore(scoreReward);
      Destroy(gameObject);
    }
  }
}
