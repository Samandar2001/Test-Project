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
    public GameObject Particle;
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
            GameObject particle = Instantiate(Particle, Tower.transform.position, Quaternion.identity);
            enemy = false;
        }
    }
    void Update()
    {
        nav.SetDestination(tower.position);        
    }
}
