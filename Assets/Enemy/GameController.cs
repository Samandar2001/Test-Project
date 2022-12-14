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
    void Start()
    {
        
        
    }
    private void Awake()
    {
        InsSlinder();
        //PlayerIns();
        EnemyIns();
        PlayerIns();
        StartCoroutine(EnemyOnOf());
        Connect();
    }
    public void PlayerIns()
    {
        for (int i = 0; i < 20; i++)
        {
            Vector3 playerPos = new Vector3(Random.Range(-20, 20), 1, Random.Range(-30, -20));
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
    public int k = 0;
    public void ButtonOn()
    {
        if (son <= 0)
        {

        }
        else
        {
            PlayerList[k].SetActive(true);
            k += 1;
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
        for (int i = 0; i < 18; i++)
        {
            Vector3 enemyPos = new Vector3(Random.Range(-20, 20), 1, Random.Range(40, 10));
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
        SlinderList.Add(slinderParent);
        GameObject ui = Instantiate(UI, new Vector3(slinderParent.transform.position.x, slinderParent.transform.position.y, slinderParent.transform.position.z - 4.6f), Quaternion.identity);
        UIList.Add(ui);
    }   
    IEnumerator Youlose()
    {        
        yield return new WaitForSecondsRealtime(3f);
        YouLose.SetActive(true);
    }
    private void Update()
    {
        if (!SlinderList[0].GetComponent <SlinderParent>().SlinderList[17].activeInHierarchy)
        {
            StartCoroutine(Youlose());
            Plane.GetComponent<MeshRenderer>().material = EnemyWin;
            //TabloSon.GetComponent<Son>().Equals(false);
            TabloSon.GetComponent<Son>().on = false;
            UIList[0].SetActive(false);
        }        
    }
}

