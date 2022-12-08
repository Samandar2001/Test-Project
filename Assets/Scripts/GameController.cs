using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Samandar
{
    public class GameController : MonoBehaviour
    {
        public GameObject Slinder;
        public GameObject SlinderOch;
        public GameObject SlinderParent;
        public List<GameObject> SlinderList;
        private void Start()
        {
            InsSlinder();
        }

        void InsSlinder()
        {
            for (float i = 1.5f; i < 15; i += 6)
            {
                GameObject slinder = Instantiate(Slinder, new Vector3(0, i, 0), Quaternion.identity, SlinderParent.transform);
                SlinderList.Add(slinder);
            }
            for (float i = 4.5f; i < 18; i += 6)
            {
                GameObject slinder = Instantiate(SlinderOch, new Vector3(0, i, 0), Quaternion.identity, SlinderParent.transform);
                SlinderList.Add(slinder);
            }
        }
    }
}
