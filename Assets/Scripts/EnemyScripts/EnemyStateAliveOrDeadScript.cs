using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateAliveOrDeadScript : MonoBehaviour
{
    public string State;

    public void SetState(string newState)
    {
        State = newState;
    }

    public string GetState()
    {
        return State;
    }
}
