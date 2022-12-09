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
    public List<GameObject> EnemyList;
    public GameObject Pos1;
    public GameObject Pos2;
    public GameObject Slinder;
    public GameObject SlinderOch;
    public GameObject SlinderParent;
    public List<GameObject> SlinderList;
    void Start()
    {
        
        
    }
    private void Awake()
    {
        InsSlinder();
        PlayerIns();
        EnemyIns();
        StartCoroutine(EnemyOnOf());

    }
    public void PlayerIns()
    {
        if (PlayerList.Count == 20)
        {
            for (int i = 0; i < PlayerList.Count ; i++)
            {
                PlayerList[i].SetActive(true);
            }
        }
        else
        {
            Vector3 playerPos = new Vector3(Random.Range(-40, 40), 1, Random.Range(-40, 0));
            GameObject player = Instantiate(Player, playerPos, Quaternion.identity, PlayerParent.transform);
            PlayerList.Add(player);
        }
                     
    }
    void EnemyIns()
    {
        for (int i = 0; i < 20; i++)
        {
            GameObject enemy = Instantiate(Enemy, Pos2.transform.position, Quaternion.identity, EnemyParent.transform);
            EnemyList.Add(enemy);
        }
        for (int i = 0; i < EnemyList.Count; i++)
        {
            EnemyList[i].SetActive(false);
        }

    }
    IEnumerator EnemyOnOf()
    {        
        for (int i = 0; i < EnemyList.Count; i++)
        {
            EnemyList[i].SetActive(true);
            yield return new WaitForSecondsRealtime(3f);
        }

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

