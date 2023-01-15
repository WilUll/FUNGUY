using System.Collections;
using System.Collections.Generic;
using AI;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using Sequence = AI.Sequence;

public class SimpleFungiBT : AI.Tree
{
    public NavMeshAgent _agent;
    public Transform[] _waypoints;

    public static float fovRange = 6f;
    
    public static int LayerMask = (1 << 7) | (1 << 8);

    public static float AttackRange = 1.5f;

    public static float speed = 2f;
    
    public static float attackSpeed = 1f;
    
    public static float attackDamage = 5f;
    
    protected override Node SetupTree()
    {
        Node root = new Selector(new List<Node>
        {
            new Sequence(new List<Node>
            {
                new TaskCheckIfInAttackRange(_agent),
                new TaskAttack()
            }),
            new Sequence(new List<Node>
            {
                new TaskCheckEnemyInFOVRange(_agent),
                new TaskGoToTarget(_agent)
            }),
            new TaskPatrol(_agent, _waypoints),
        });

        return root;
    }
}
