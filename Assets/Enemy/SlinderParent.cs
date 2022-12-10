using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlinderParent : MonoBehaviour
{
    public GameObject Slinder;
    public GameObject SlinderOch;    
    public List<GameObject> SlinderList;
    void Start()
    {
        InsSlinder();
    }
    void InsSlinder()
    {        
        for (float i = 0.5f; i < 17; i += 2)
        {
            GameObject slinder = Instantiate(Slinder, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + i, gameObject.transform.position.z), Quaternion.identity, gameObject.transform);
            SlinderList.Add(slinder);
        }
        for (float i = 1.5f; i < 18; i += 2)
        {
            GameObject slinder = Instantiate(SlinderOch, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + i, gameObject.transform.position.z), Quaternion.identity, gameObject.transform);
            SlinderList.Add(slinder);
        }
    }
    
    void Update()
    {
        
    }
}
