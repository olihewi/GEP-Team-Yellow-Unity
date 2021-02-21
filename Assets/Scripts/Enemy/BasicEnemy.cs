using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BasicEnemy : Ship
{
  public CommandSequence movementSequence;
  private int currentCommandIndex;
  private float commandTimer;
  public FirePattern firePattern;
  private int currentFirePatternIndex;
  private float fireTimer;
  private bool startedMovement = false;


  public void startMovement()
  {
    startedMovement = true;
  }
  private void Update()
  {
    if (startedMovement)
    {
      CommandSequenceStep();
      FirePatternStep();
    }
  }

  private void CommandSequenceStep()
  {
    if (currentCommandIndex < movementSequence.commands.Count)
    {
      Vector2 thisPos = movementSequence.commands[currentCommandIndex].movement.GetPoint(commandTimer / movementSequence.commands[currentCommandIndex].duration);
      Vector3 moveVector = new Vector3(thisPos.x, thisPos.y, 0);
      transform.localPosition = moveVector;
      if (commandTimer >= movementSequence.commands[currentCommandIndex].duration)
      {
        currentCommandIndex++;
        commandTimer = 0;
        if (currentCommandIndex >= movementSequence.commands.Count && movementSequence.looping)
        {
          currentCommandIndex = 0;
        }
      }
      commandTimer += Time.deltaTime;
    }
  }
  private void FirePatternStep()
  {
    if (currentFirePatternIndex < firePattern.sequences.Count)
    {
      foreach (FirePatternElement element in firePattern.sequences[currentFirePatternIndex].elements)
      {
        if (fireTimer <= element.time && fireTimer + Time.deltaTime >= element.time)
        {
          BasicProjectile bullet = Instantiate(element.projectile, transform.position, Quaternion.Euler(0, 0, element.rotation));
          bullet.collisionTag = "Player";
        }
      }
      fireTimer += Time.deltaTime;
      if (fireTimer >= firePattern.sequences[currentFirePatternIndex].duration)
      {
        currentFirePatternIndex++;
        fireTimer = 0;
        if (currentFirePatternIndex >= firePattern.sequences.Count)
        {
          currentFirePatternIndex = 0;
        }
      }
    }
  }
  public override void OnDestroyOther(Ship _other) {}
}
