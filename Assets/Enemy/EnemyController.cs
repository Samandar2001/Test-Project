using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private Transform player;
    private GameObject PlayerDelete;
    private Transform tower;
    private NavMeshAgent nav;
    public bool enemy = true;
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player").transform;
        tower = GameObject.FindGameObjectWithTag("TOWER").transform;
        
        nav = GetComponent<NavMeshAgent>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerDelete = GameObject.FindGameObjectWithTag("Player");
            PlayerDelete.SetActive(false);
            gameObject.SetActive(false);
            //Destroy(PlayerDelete);
            //Destroy(gameObject);
            enemy = false;
        }
    }
    void Update()
    {
        nav.SetDestination(tower.position);
        //if (enemy)
        //{
        //    //nav.SetDestination(player.position);
        //}
        //else
        //{
            
        //}
        //bool _player = GameObject.FindGameObjectWithTag("Player");
        //bool _tower = GameObject.FindGameObjectWithTag("TOWER");
        //if (_tower && _player)
        //{
        //    nav.SetDestination(player.position);
        //}
        //else if (_player)
        //{
        //    nav.SetDestination(player.position);
        //}
        //else if (_tower)
        //{
        //    nav.SetDestination(tower.position);
        //}

    }
}
