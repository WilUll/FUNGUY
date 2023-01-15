using System.Collections;
using System.Collections.Generic;
using AI;
using UnityEngine;

public class TaskAttack : Node
{
    private Transform _lastTarget;
    private HealthComponent _healthComponent;

    private float _attackCounter;

    public override NodeState Evaluate()
    {
        Transform target = (Transform)GetData("target");
        if (target != _lastTarget)
        {
            _healthComponent = target.GetComponent<HealthComponent>();
            _lastTarget = target;
        }
        
        _attackCounter += Time.deltaTime;
        if (_attackCounter >= SimpleFungiBT.attackSpeed)
        {
            bool isEnemyDead = _healthComponent.TakeDamage(SimpleFungiBT.attackDamage);
            if (isEnemyDead)
            {
                ClearData("target");
            }
            else
            {
                _attackCounter = 0;
            }
        }

        state = NodeState.RUNNING;
        return state;
    }
}
