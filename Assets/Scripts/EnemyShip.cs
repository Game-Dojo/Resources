using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class EnemyShip : MonoBehaviour
{
    private NavMeshAgent _agent;
    
    
    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
       InvokeRepeating(nameof(ChooseRandomPosition), 0f, 3f);
    }

    private void ChooseRandomPosition()
    {
        Vector3 randomPoint = transform.position + Random.insideUnitSphere * 30f;
        NavigateTo(randomPoint);
    }

    private void NavigateTo( Vector3 hit )
    {
        if (NavMesh.SamplePosition(hit, out NavMeshHit navMeshHit,10, NavMesh.AllAreas))
        {
            _agent.SetDestination(hit);    
        }
    }
}
