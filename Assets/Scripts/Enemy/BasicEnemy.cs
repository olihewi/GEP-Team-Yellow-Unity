using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
  public int healthPoints = 1;
  public int scoreReward = 1;

  public CommandSequence commandSequence;
  private int currentCommandIndex;
  private float commandTimer = 0;

  public void Damage(int _damage, PlayerController _player)
  {
    healthPoints -= _damage;
    if (healthPoints <= 0)
    {
      _player.AddScore(scoreReward);
      Destroy(gameObject);
    }
  }

  private void Update()
  {
    if (currentCommandIndex < commandSequence.commands.Count)
    {
      Vector2 thisPos = commandSequence.commands[currentCommandIndex].movement.GetPoint(commandTimer / commandSequence.commands[currentCommandIndex].duration);
      Vector3 moveVector = new Vector3(thisPos.x, thisPos.y, 0);
      transform.position = moveVector;
      if (commandTimer >= commandSequence.commands[currentCommandIndex].duration)
      {
        currentCommandIndex++;
        commandTimer = 0;
        if (currentCommandIndex >= commandSequence.commands.Count && commandSequence.looping)
        {
          currentCommandIndex = 0;
        }
      }
      commandTimer += Time.deltaTime;
    }
  }
}
