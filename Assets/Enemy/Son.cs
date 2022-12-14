using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Son : MonoBehaviour
{
    public GameController GameController;
    public TMP_Text TabloSon;
    public bool on = true;   
    void Start()
    {
        StartCoroutine(TablogaSonQoshish());
    }
    IEnumerator TablogaSonQoshish()
    {
        if (on)
        {
            GameController.son = GameController.son + 10;
            TabloSon.text = GameController.son.ToString();
            yield return new WaitForSecondsRealtime(3f);
            StartCoroutine(TablogaSonQoshish());
        }
        
    }
    void Update()
    {
        
    }
}
