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
    public bool playerBool;
    void Start()
    {      
        nav = GetComponent<NavMeshAgent>();
    }
    private void OnEnable()
    {
        enemy = true;
    }
    private void OnDisable()
    {
        enemy = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "TOWER")
        {
            Tower = GameObject.FindGameObjectWithTag("TOWER");            
            Tower.SetActive(false);
            gameObject.SetActive(false);
            Vector3 enemyPos = new Vector3(Random.Range(0, 35), 1, Random.Range(10, 35));
            gameObject.transform.position = enemyPos;            
        }
        else if (other.tag == "Player")
        {
            Player = GameObject.FindGameObjectWithTag("Player");
            Player.SetActive(false);
            gameObject.SetActive(false);
            Vector3 enemyPos = new Vector3(Random.Range(0, 35), 1, Random.Range(10, 35));
            gameObject.transform.position = enemyPos;
            Vector3 playerPos = new Vector3(Random.Range(-35, 0), 1, Random.Range(-35, -5));
            Player.transform.position = playerPos;
            //enemy = false;
            //GameController.GameTrue = false;
        }
    }
    void Update()
    {       
        for (int i = 0; i < GameController.PlayerList.Count; i++)
        {
            playerBool = GameController.PlayerList[i].GetComponent<PlayerMove>().playerBool;
            if (GameController.player)
            {
                player = GameObject.FindGameObjectWithTag("Player").transform;
                Debug.Log("1");
                nav.SetDestination(player.position);
            }          
            else
            {
                Debug.Log("2");
                tower = GameObject.FindGameObjectWithTag("TOWER").transform;
                nav.SetDestination(tower.position);
            }
        }  
    }
}
