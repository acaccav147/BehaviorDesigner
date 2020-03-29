using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyExample
{
    //防御塔暂时没用行为树
    public class SoldierProxy : MonoBehaviour
    {
        // Start is called before the first frame update
        public int Hp;
        public List<GameObject> enemys;

        public GameObject bullet;
        private GameObject target;
        public float interval = 1.0f;
        private float nextTime;
        void Start()
        {
            Hp = 100;
        }

        // Update is called once per frame
        void Update()
        {
            if(this.Hp <= 0)
            {
                Debug.LogError("soldier dead..");
                GameObject.Destroy(this.gameObject);
                return;
            }
            if(bullet)
                Shoot(GetDistanceEnemy());
        }

        private GameObject GetDistanceEnemy()
        {
            GameObject[] objs = GameObject.FindGameObjectsWithTag("Enemy");
            float distance = float.MaxValue;
            
            if(objs.Length > 0)
            {
                target = objs[0];
                var itor = objs.GetEnumerator();
                while(itor.MoveNext())
                {
                    var item = (GameObject)itor.Current;
                    float dis = Vector3.Distance(this.transform.position, item.transform.position);
                    if(dis < distance)
                    {
                        distance = dis;
                        target = item;
                    }
                }
            }

            return target;
        }

        private void Shoot(GameObject go)
        {
            if(go == null)
                return;

            nextTime += Time.deltaTime;
            if(nextTime >= interval)
            {
                //创建子弹
                var bu = GameObject.Instantiate(bullet);
                bu.GetComponent<BulletProxy>().Init(go);
                nextTime = 0;
            }
        }
    
        public void OnDamage(int damage_)
        {
            this.Hp -= damage_;
        }
    }
}