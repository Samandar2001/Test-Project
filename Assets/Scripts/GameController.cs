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
    public GameObject SlinderParent;
    public List<GameObject> SlinderList;
    public GameObject UI;
    public TMP_Text TabloSon;
    public GameObject YouLose;
    public Material EnemyWin;
    public GameObject Plane;
    public List<GameObject> UIList;
    public int son = 0;
    public bool GameTrue;
    public int k = 0;
    public int l = 0;
    public bool enemy;
    public bool player;    
    void Start()
    {        
        
    }
    private void Awake()
    {
        EnemyIns();
        PlayerIns();
        StartCoroutine(EnemyOnOf());
        Connect();
    }
    public void PlayerIns()
    {
        for (int i = 0; i < 30; i++)
        {
            Vector3 playerPos = new Vector3(Random.Range(-35, 0), 1, Random.Range(-35, -5));
            GameObject player = Instantiate(Player, playerPos, Quaternion.identity, PlayerParent.transform);
            PlayerList.Add(player);
        }
        if (PlayerList.Count >= 20)
        {
            for (int i = 0; i < PlayerList.Count; i++)
            {
                PlayerList[i].SetActive(false);
            }
        }
    }
    
    public void ButtonOn()
    {
        if (son <= 0)
        {

        }
        else
        {
            if (k >= 30)
            {
                k = 0;
            }
            else
            {
                PlayerList[k].SetActive(true);
                k += 1;
            }
        }
        if (son >= 10)
        {
            son = son - 10;
            TabloSon.text = son.ToString();
        }
        else
        {

        }
        GameTrue = true; 
    }
    void EnemyIns()
    {
        for (int i = 0; i < 30; i++)
        {
            Vector3 enemyPos = new Vector3(Random.Range(0, 35), 1, Random.Range(10, 35));
            GameObject enemy = Instantiate(Enemy, enemyPos, Quaternion.identity, EnemyParent.transform);
            EnemyList.Add(enemy);
        }
        for (int i = 0; i < EnemyList.Count; i++)
        {
            EnemyList[i].SetActive(false);
        }
    }
    void Connect()
    {
        for (int i = 0; i < EnemyList.Count; i++)
        {
            EnemyList[i].GetComponent<EnemyController>().GameController = this;
        }
        for (int i = 0; i < PlayerList.Count; i++)
        {
            PlayerList[i].GetComponent<PlayerMove>().gameController = this;
        }
    }
    IEnumerator EnemyOnOf()
    {
        if (l >= 30)
        {
            l = 0;
        }
        else
        {
            EnemyList[l].SetActive(true);
            l += 1;
                
        }                     
        yield return new WaitForSecondsRealtime(4f);
        StartCoroutine(EnemyOnOf());
    }    
    IEnumerator Youlose()
    {        
        yield return new WaitForSecondsRealtime(3f);
        YouLose.SetActive(true);
    }
    private void Update()
    {
        for (int i = 0; i < EnemyList.Count; i++)
        {
            if (EnemyList[i].GetComponent<EnemyController>().enemy == true)
            {
                enemy = true;
            }
            else
            {
                enemy = false;
            }
            
        }
        for (int i = 0; i < PlayerList.Count; i++)
        {
            if (PlayerList[i].GetComponent<PlayerMove>().playerBool == true)
            {
                player = true;
            }
            else
            {
                player = false;
            }
        }
        //if (!SlinderList[0].GetComponent<SlinderParent>().SlinderList[17].activeInHierarchy)
        //{
        //    StartCoroutine(Youlose());
        //    Plane.GetComponent<MeshRenderer>().material = EnemyWin;
        //    //TabloSon.GetComponent<Son>().Equals(false);
        //    TabloSon.GetComponent<Son>().on = false;
        //    UIList[0].SetActive(false);
        //}
    }
}

