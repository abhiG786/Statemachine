using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyState
{
    void EnterState(Enemy enemy);  // Method for entering the state
    void UpdateState(Enemy enemy); // Method for updating the state logic
    void ExitState(Enemy enemy);   // Method for exiting the state
}
