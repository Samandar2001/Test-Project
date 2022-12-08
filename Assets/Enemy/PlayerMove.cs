using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMove : MonoBehaviour
{
    public float movesSpeed;
    public float rotateSpeed;
    private Transform player;
    private NavMeshAgent nav;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Enemy").transform;
        nav = GetComponent<NavMeshAgent>();
    }
    //private void Update()
    //{
    //    transform.Translate(0, 0, Input.GetAxis("Vertical") * Time.deltaTime * movesSpeed);
    //    transform.Rotate(0, Input.GetAxis("Horizontal") * Time.deltaTime * rotateSpeed, 0);
    //}
    void Update()
    {
        nav.SetDestination(player.position);
    }
}
