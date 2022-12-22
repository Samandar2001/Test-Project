using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMove : MonoBehaviour
{
    public GameController gameController;
    private GameObject Tower;
    private GameObject Player;
    public float movesSpeed;
    public float rotateSpeed;
    private Transform player;
    private Transform tower;
    private NavMeshAgent nav;
    public bool _true;
    public bool playerBool;
    public bool enemy;
    private void Start()
    {
       
        nav = GetComponent<NavMeshAgent>();
    }
    private void OnEnable()
    {
        playerBool = true;
    }
    private void OnDisable()
    {
        playerBool = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Tower")
        {
            Tower = GameObject.FindGameObjectWithTag("Tower");
            Tower.SetActive(false);
            gameObject.SetActive(false);
            Vector3 playerPos = new Vector3(Random.Range(-35, 0), 1, Random.Range(-35, -5));
            gameObject.transform.position = playerPos;
        }
        else if (other.tag == "Enemy")
        {
            Player = GameObject.FindGameObjectWithTag("Enemy");
            Player.SetActive(false);
            gameObject.SetActive(false);
            Vector3 playerPos = new Vector3(Random.Range(-35, 0), 1, Random.Range(-35, -5));
            gameObject.transform.position = playerPos;
            Vector3 enemyPos = new Vector3(Random.Range(0, 35), 1, Random.Range(10, 40));
            Player.transform.position = enemyPos;
            
              
        }
    }     
    [System.Obsolete]
    void Update()
    {
        tower = GameObject.FindGameObjectWithTag("Tower").transform;
        player = GameObject.FindGameObjectWithTag("Enemy").transform;
        
        for (int i = 0; i < gameController.EnemyList.Count; i++)
        {
            enemy = gameController.EnemyList[i].GetComponent<EnemyController>().enemy;
            if (gameController.enemy)
            {
                //player = GameObject.FindGameObjectWithTag("Enemy").transform;
                Debug.Log("1");
                nav.SetDestination(player.position);
            }
            else
            {
                Debug.Log("2");
                //tower = GameObject.FindGameObjectWithTag("Tower").transform;
                nav.SetDestination(tower.position);
            }
        }      
    }
}
