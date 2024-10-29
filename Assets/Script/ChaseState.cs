using UnityEngine;

public class ChaseState : IEnemyState
{
    private float minX = -50f; // Minimum X boundary
    private float maxX = 50f;  // Maximum X boundary
    private float minZ = -50f; // Minimum Z boundary
    private float maxZ = 50f;  // Maximum Z boundary

    public void EnterState(Enemy enemy)
    {
        Debug.Log("Entering Chase State");
    }

    public void UpdateState(Enemy enemy)
    {
        ChasePlayer(enemy);

        // If player is too far, return to patrol state
        if (Vector3.Distance(enemy.transform.position, enemy.playerTransform.position) > enemy.detectionRange)
        {
            enemy.TransitionToState(enemy.patrolState);
        }
    }

    public void ExitState(Enemy enemy)
    {
        Debug.Log("Exiting Chase State");
    }

    private void ChasePlayer(Enemy enemy)
    {
        // Move towards the player
        Vector3 direction = (enemy.playerTransform.position - enemy.transform.position).normalized;
        enemy.transform.Translate(direction * enemy.speed * Time.deltaTime);

        // Clamp the enemy's position to stay within the boundaries
        StayWithinBounds(enemy);
    }

    // Clamp the enemy's position within defined boundaries
    private void StayWithinBounds(Enemy enemy)
    {
        Vector3 pos = enemy.transform.position;
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.z = Mathf.Clamp(pos.z, minZ, maxZ);
        enemy.transform.position = pos;
    }
}
