using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<EnemySpawn> enemySpawns;
    public BoxCollider2D levelCollider;
    private List<BasicEnemy> currentEnemies = new List<BasicEnemy>();
    private float levelBounds;

    void Start()
    {
        levelBounds = levelCollider.size.y / 2;
    }

    void Update()
    {
        foreach (EnemySpawn spawn in enemySpawns)
        {
            if (transform.position.y + levelBounds >= spawn.spawnPos && !spawn.GetSpawned())
            {
                BasicEnemy thisEnemy = Instantiate(spawn.enemy, new Vector3(spawn.enemy.movementSequence.commands[0].movement.points[0].x, transform.position.y + levelBounds, 0), Quaternion.identity);
                currentEnemies.Add(thisEnemy);
                spawn.SetSpawned();
            }
        }
        foreach (BasicEnemy enemy in currentEnemies)
        {
            if (enemy.transform.position.y - enemy.movementSequence.commands[0].movement.points[0].y <= transform.position.y)
            {
                enemy.startMovement();
                enemy.transform.parent = transform;
                currentEnemies.Remove(enemy);
                break;
            }
        }
    }
}
[System.Serializable]
public class EnemySpawn
{
    public BasicEnemy enemy;
    public float spawnPos;

    public void SetSpawned()
    {
        isSpawned = true;
    }

    public bool GetSpawned()
    {
        return isSpawned;
    }
    private bool isSpawned = false;
}
