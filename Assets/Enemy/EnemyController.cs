using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private Transform player;
    private Transform tower;
    private NavMeshAgent nav;    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        tower = GameObject.FindGameObjectWithTag("TOWER").transform;
        
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        bool _player = GameObject.FindGameObjectWithTag("Player");
        bool _tower = GameObject.FindGameObjectWithTag("TOWER");
        if (_tower && _player)
        {
            nav.SetDestination(player.position);
        }
        else if (_player && !_tower)
        {
            nav.SetDestination(player.position);
        }
        else if (!_player && _tower)
        {
            nav.SetDestination(tower.position);
        }

    }
}
