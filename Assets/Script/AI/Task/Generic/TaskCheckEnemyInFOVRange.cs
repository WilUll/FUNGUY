using System.Collections;
using System.Collections.Generic;
using AI;
using UnityEngine;
using UnityEngine.AI;
using Tree = AI.Tree;

public class TaskCheckEnemyInFOVRange : Node
{
    private NavMeshAgent _agent;
    
    public TaskCheckEnemyInFOVRange(NavMeshAgent agent)
    {
        _agent = agent;
    }

    public override NodeState Evaluate()
    {
        object t = GetData("target");
        if (t == null)
        {
            Collider[] colliders = 
                Physics.OverlapSphere(_agent.transform.position, SimpleFungiBT.fovRange, SimpleFungiBT.LayerMask);

            if (colliders.Length > 0)
            {
                foreach (Collider collider in colliders)
                {
                    if (collider.gameObject != _agent.gameObject)
                    {
                        parent.parent.SetData("target", collider.transform);
                        state = NodeState.SUCCESS;
                        return state;
                    }
                }
            }

            state = NodeState.FAILURE;
            return state;
        }

        state = NodeState.SUCCESS;
        return state;
    }
}
