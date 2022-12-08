using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject Player;
    public GameObject PlayerParent;
    public List<GameObject> PlayerList;
    public GameObject Enemy;
    public GameObject EnemyParent;
    public GameObject Pos1;
    public GameObject Pos2;
    void Start()
    {
        StartCoroutine(PlayerIns());
        StartCoroutine(EnemyIns());
    }

    IEnumerator PlayerIns()
    {
        for (int i = 0; i < 1; i++)
        {
            GameObject player = Instantiate(Player, Pos1.transform.position, Quaternion.identity, PlayerParent.transform);
            PlayerList.Add(player);
        }
        yield return new WaitForSecondsRealtime(3f);
        StartCoroutine(PlayerIns());
    }
    IEnumerator EnemyIns()
    {
        for (int i = 0; i < 1; i++)
        {
            GameObject enemy = Instantiate(Enemy, Pos2.transform.position, Quaternion.identity, EnemyParent.transform);
            
        }        
        yield return new WaitForSecondsRealtime(3f);
        StartCoroutine(EnemyIns());
    }
    void Update()
    {
        
    }
}
