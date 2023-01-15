namespace AI
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.AI;
    using IsopodaFramework.Vectors;
    public class TaskPatrol : Node
    {
        private NavMeshAgent _agent;
        private Transform[] _waypoints;

        private int _currentWaypoint = 0;

        private float _waitTime = 1f;
        private float _waitCounter = 0f;
        private bool _isWating = false;

        public TaskPatrol(NavMeshAgent agent, Transform[] waypoints)
        {
            _agent = agent;
            _waypoints = waypoints;
        }

        public override NodeState Evaluate()
        {
            if (_isWating)
            {
                _waitCounter += Time.deltaTime;
                if (_waitCounter >= _waitTime)
                {
                    _isWating = false;
                }
            }
            else
            {
                Transform waypoint = _waypoints[_currentWaypoint];
                if (Vector3.Distance( _agent.transform.position.XZPlane(),waypoint.position.XZPlane()) < 0.1f)
                {
                    _waitCounter = 0;
                    _isWating = true;

                    _currentWaypoint = (_currentWaypoint + 1) % _waypoints.Length;
                }
                else
                {
                    _agent.SetDestination(waypoint.position);
                    _agent.speed = 2f;
                    _agent.isStopped = false;
                }
            }

            state = NodeState.RUNNING;
            return state;
        }
    }

}