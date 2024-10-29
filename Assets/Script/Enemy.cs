using UnityEngine;

public class Enemy : MonoBehaviour
{
    public PatrolState patrolState = new PatrolState();
    public AlertState alertState = new AlertState();
    public ChaseState chaseState = new ChaseState();
    public HuntState huntState = new HuntState();

    public Transform playerTransform;  // Assign in the Inspector
    public float detectionRange = 15f;
    public float chaseRange = 510f;
    public float speed = 5f;

    private IEnemyState currentState;

    void Start()
    {
        currentState = patrolState;
        currentState.EnterState(this);
    }

    void Update()
    {
        currentState.UpdateState(this);
    }

    public void TransitionToState(IEnemyState newState)
    {
        currentState.ExitState(this);
        currentState = newState;
        currentState.EnterState(this);
    }
}
