using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyExample
{
    public class BulletProxy : MonoBehaviour
    {
        public GameObject target;
        private float speed = 20.0f;
        public void Init(GameObject go)
        {
            this.target = go;
        }
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            if(target == null)
            {
                GameObject.Destroy(this.gameObject);
                return;
            }

            this.transform.position = Vector3.MoveTowards(this.transform.position, target.transform.position, Time.deltaTime * speed);
            if(Vector3.Distance(this.transform.position, target.transform.position) < 0.3f)
            {
                GameObject.Destroy(this.gameObject);
                target.transform.GetComponent<SoldierProxy>().OnDamage(50);
            }
        }
    }
}