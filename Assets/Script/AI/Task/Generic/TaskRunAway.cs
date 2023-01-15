using System.Collections;
using System.Collections.Generic;
using AI;
using IsopodaFramework.Vectors;
using UnityEngine;
using UnityEngine.AI;

public class TaskRunAway : Node
{
    private NavMeshAgent _agent;
    
    public TaskRunAway(NavMeshAgent agent)
    {
        _agent = agent;
    }

    public override NodeState Evaluate()
    {
        Transform target = (Transform)GetData("target");
        
        float distance = Vector3.Distance(_agent.transform.position.XZPlane(), target.position.XZPlane());
        
        Debug.Log(distance);

        if (distance > 10f)
        {
            ClearData("target");
            state = NodeState.SUCCESS;
            return state;
        }
        else
        {
            _agent.SetDestination((_agent.transform.position - target.transform.position ).normalized * 20f);
        }

        state = NodeState.RUNNING;
        return state;
    }
}
