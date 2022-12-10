using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private GameObject Tower;
    private Transform tower;
    private NavMeshAgent nav;
    public bool enemy = true;
    void Start()
    {        
        tower = GameObject.FindGameObjectWithTag("TOWER").transform;        
        nav = GetComponent<NavMeshAgent>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "TOWER")
        {
            Tower = GameObject.FindGameObjectWithTag("TOWER");
            Tower.SetActive(false);
            gameObject.SetActive(false);       
            enemy = false;
        }
    }
    void Update()
    {
        nav.SetDestination(tower.position);        
    }
}
