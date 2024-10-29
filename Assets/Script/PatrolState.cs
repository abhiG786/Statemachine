using UnityEngine;

public class PatrolState : IEnemyState
{
    private float patrolTime = 3f; // Time to move in one direction before turning
    private float patrolTimer;
    private Vector3 patrolDirection;

    private float minX = -50f; // Minimum X boundary
    private float maxX = 50f;  // Maximum X boundary
    private float minZ = -50f; // Minimum Z boundary
    private float maxZ = 50f;  // Maximum Z boundary

    public void EnterState(Enemy enemy)
    {
        Debug.Log("Entering Patrol State");
        patrolDirection = Vector3.forward; // Start moving forward
        patrolTimer = patrolTime; // Initialize patrol timer
    }

    public void UpdateState(Enemy enemy)
    {
        Patrol(enemy);

        // Transition to AlertState if the player is within detection range
        if (Vector3.Distance(enemy.transform.position, enemy.playerTransform.position) < enemy.detectionRange)
        {
            enemy.TransitionToState(enemy.alertState);
        }
    }

    public void ExitState(Enemy enemy)
    {
        Debug.Log("Exiting Patrol State");
    }

    private void Patrol(Enemy enemy)
    {
        // Move the enemy in the current patrol direction
        enemy.transform.Translate(patrolDirection * enemy.speed * Time.deltaTime);

        // Update patrol timer to change direction after a certain time
        patrolTimer -= Time.deltaTime;
        if (patrolTimer <= 0f)
        {
            // Reverse the patrol direction when the timer runs out
            patrolDirection = -patrolDirection;
            patrolTimer = patrolTime;
        }

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

        // If hitting a boundary, reverse patrol direction
        if (pos.x == minX || pos.x == maxX || pos.z == minZ || pos.z == maxZ)
        {
            patrolDirection = -patrolDirection;
        }
    }
}
