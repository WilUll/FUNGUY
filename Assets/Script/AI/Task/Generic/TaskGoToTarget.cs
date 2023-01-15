using System.Collections;
using System.Collections.Generic;
using AI;
using IsopodaFramework.Vectors;
using UnityEngine;
using UnityEngine.AI;

public class TaskGoToTarget : Node
{
    private NavMeshAgent _agent;
    
    public TaskGoToTarget(NavMeshAgent agent)
    {
        _agent = agent;
    }

    public override NodeState Evaluate()
    {
        Transform target = (Transform)GetData("target");

        float distance = Vector3.Distance(_agent.transform.position.XZPlane(), target.position.XZPlane());
        
        Debug.Log(distance);

        if (distance > 0.1f && distance < 10f)
        {
            _agent.SetDestination(target.position);
        }
        else
        {
            ClearData("target");
            state = NodeState.FAILURE;
            return state;
        }

        state = NodeState.RUNNING;
        return state;
    }
}
