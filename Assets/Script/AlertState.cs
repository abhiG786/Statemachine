using UnityEngine;

public class AlertState : IEnemyState
{
    public void EnterState(Enemy enemy)
    {
        Debug.Log("Entered Alert State");
    }

    public void UpdateState(Enemy enemy)
    {
        // Check the distance between the enemy and player
        float distanceToPlayer = Vector3.Distance(enemy.transform.position, enemy.playerTransform.position);

        // If the player is within the chase range, switch to chase state
        if (distanceToPlayer < enemy.chaseRange)
        {
            enemy.TransitionToState(enemy.chaseState);  // Change 'ChangeState' to 'TransitionToState'
        }
        // If the player is too far, return to patrol state
        else if (distanceToPlayer > enemy.detectionRange)
        {
            enemy.TransitionToState(enemy.patrolState);  // Change 'ChangeState' to 'TransitionToState'
        }
    }

    public void ExitState(Enemy enemy)
    {
        Debug.Log("Exited Alert State");
    }
}
