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
    public GameObject Slinder;
    public GameObject SlinderOch;
    public GameObject SlinderParent;
    public List<GameObject> SlinderList;
    void Start()
    {
        //InsSlinder();
        StartCoroutine(PlayerIns());
        StartCoroutine(EnemyIns());
        
    }

    IEnumerator PlayerIns()
    {
        Vector3 playerPos = new Vector3(Random.Range(-40, 40), 1, Random.Range(-40, 0));
        for (int i = 0; i < 1; i++)
        {
            GameObject player = Instantiate(Player, playerPos, Quaternion.identity, PlayerParent.transform);
            PlayerList.Add(player);
        }
        yield return new WaitForSecondsRealtime(15f);
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
    void InsSlinder()
    {
        for (float i = 0.5f; i < 17; i += 2)
        {
            GameObject slinder = Instantiate(Slinder, new Vector3(SlinderParent.transform.position.x, SlinderParent.transform.position.y + i, SlinderParent.transform.position.z), Quaternion.identity, SlinderParent.transform);
            SlinderList.Add(slinder);
        }
        for (float i = 1.5f; i < 18; i += 2)
        {
            GameObject slinder = Instantiate(SlinderOch, new Vector3(SlinderParent.transform.position.x, SlinderParent.transform.position.y + i, SlinderParent.transform.position.z), Quaternion.identity, SlinderParent.transform);
            SlinderList.Add(slinder);
        }
    }
}

