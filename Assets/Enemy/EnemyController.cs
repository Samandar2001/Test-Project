using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public GameController GameController;
    private GameObject Tower;
    private GameObject Player;
    private Transform tower;
    private Transform player;
    private NavMeshAgent nav;
    public bool enemy;
    void Start()
    {
        
                
        nav = GetComponent<NavMeshAgent>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "TOWER")
        {
            Tower = GameObject.FindGameObjectWithTag("TOWER");            
            Tower.SetActive(false);
            gameObject.SetActive(false);
            Vector3 enemyPos = new Vector3(Random.Range(-20, 20), 1, Random.Range(40, 10));
            gameObject.transform.position = enemyPos;            
        }
        else if (other.tag == "Player")
        {
            Player = GameObject.FindGameObjectWithTag("Player");
            Player.SetActive(false);
            gameObject.SetActive(false);
            Vector3 enemyPos = new Vector3(Random.Range(-20, 20), 1, Random.Range(40, 10));
            gameObject.transform.position = enemyPos;
            Vector3 playerPos = new Vector3(Random.Range(-20, 20), 1, Random.Range(-30, -20));
            Player.transform.position = playerPos;
            enemy = false;
            GameController.GameTrue = false;
        }
    }
    void Update()
    {
        for (int i = 0; i < GameController.PlayerList.Count; i++)
        {            
            //enemy = GameController.PlayerList[i].GetComponent<PlayerMove>()._true;
            if (enemy = GameController.PlayerList[i].GetComponent<PlayerMove>()._true)
            {
                player = GameObject.FindGameObjectWithTag("Player").transform;
                Debug.Log("1");
                nav.SetDestination(player.position);
            }
            else if (true)
            {

            }
            else
            {
                Debug.Log("3");
                tower = GameObject.FindGameObjectWithTag("TOWER").transform;
                nav.SetDestination(tower.position);
            }
        }  
    }
}
