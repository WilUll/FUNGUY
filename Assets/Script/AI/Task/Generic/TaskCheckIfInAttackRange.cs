using System.Collections;
using System.Collections.Generic;
using AI;
using IsopodaFramework.Vectors;
using UnityEngine;
using UnityEngine.AI;

public class TaskCheckIfInAttackRange : Node
{
    private NavMeshAgent _agent;
    
    public TaskCheckIfInAttackRange(NavMeshAgent agent)
    {
        _agent = agent;
    }

    public override NodeState Evaluate()
    {
        object t = GetData("target");
        if (t == null)
        {
            state = NodeState.FAILURE;
            return state;
        }
        
        Transform target = (Transform) t;
        if (Vector3.Distance(_agent.transform.position.XZPlane(), target.position.XZPlane()) <= SimpleFungiBT.AttackRange)
        {
            state = NodeState.SUCCESS;
            return state;
        }
        
        state = NodeState.FAILURE;
        return state;
    }
}
