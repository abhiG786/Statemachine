using UnityEngine;

public class HuntState : IEnemyState
{
    public void EnterState(Enemy enemy)
    {
        Debug.Log("Entered Hunt State");
    }

    public void UpdateState(Enemy enemy)
    {
        // Calculate distance to the player
        float distanceToPlayer = Vector3.Distance(enemy.transform.position, enemy.playerTransform.position);

        // Move toward the player at chase speed
        enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, enemy.playerTransform.position, enemy.speed * Time.deltaTime);

        // Check if player is out of chase range and switch back to Patrol if necessary
        if (distanceToPlayer > enemy.chaseRange)
        {
            enemy.TransitionToState(enemy.patrolState);  // Go back to patrol if the player is too far
        }
    }

    public void ExitState(Enemy enemy)
    {
        Debug.Log("Exited Hunt State");
    }
}
