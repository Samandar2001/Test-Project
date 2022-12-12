using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
    public GameObject UI;
    public TMP_Text TabloSon;
    public int son = 0;
    void Start()
    {
        
        
    }
    private void Awake()
    {
        InsSlinder();
        //PlayerIns();
        EnemyIns();
        StartCoroutine(EnemyOnOf());
        StartCoroutine(TablogaSonQoshish());      
    }
    //public void PlayerIns()
    //{
    //    if (PlayerList.Count == 20)
    //    {
    //        for (int i = 0; i < PlayerList.Count ; i++)
    //        {
    //            PlayerList[i].SetActive(true);
    //        }
    //    }
    //    else
    //    {
    //        Vector3 playerPos = new Vector3(Random.Range(-40, 40), 1, Random.Range(-40, 0));
    //        GameObject player = Instantiate(Player, playerPos, Quaternion.identity, PlayerParent.transform);
    //        PlayerList.Add(player);
    //    }
                     
    //}
    void EnemyIns()
    {
        for (int i = 0; i < 18; i++)
        {
            Vector3 enemyPos = new Vector3(Random.Range(-40, 40), 1, Random.Range(40, 0));
            GameObject enemy = Instantiate(Enemy, enemyPos, Quaternion.identity, EnemyParent.transform);
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
            yield return new WaitForSecondsRealtime(4f);
        }

    }
    void InsSlinder()
    {
        Vector3 slinderParentPos = new Vector3(Random.Range(-20, 20), 1, Random.Range(-30, -20));
        GameObject slinderParent = Instantiate(SlinderParent, slinderParentPos, Quaternion.identity);
        GameObject ui = Instantiate(UI, new Vector3(slinderParent.transform.position.x, slinderParent.transform.position.y, slinderParent.transform.position.z - 4.6f), Quaternion.identity);
    }
    IEnumerator TablogaSonQoshish()
    {
        son = son + 10;
        TabloSon.text = son.ToString();
        yield return new WaitForSecondsRealtime(3f);
        StartCoroutine(TablogaSonQoshish());
    }
}

