using System.Collections.Generic;
using Code.Helper;
using UnityEngine;


namespace Lagger.Code.Pooling
{
    public class PoolingObject : Singleton<PoolingObject>
    {
        [SerializeField] private Transform _hoder;
        public Dictionary<string, Queue<Transform>> poolDictionary = new ();

        protected override void Awake()
        {
            base.Awake();
            poolDictionary = new Dictionary<string, Queue<Transform>>();
        }

        public void DeSpawnObj(Transform transform)
        {
            string key = Helper.getStringBeforeParenthesis(transform.name);
            transform.gameObject.SetActive(false);
            transform.SetParent(_hoder);
            if (poolDictionary.ContainsKey(key))
            {
                poolDictionary[key].Enqueue(transform);
                return;
            }
            Queue<Transform> pools = new Queue<Transform>();
            pools.Enqueue(transform);
            poolDictionary.Add(transform.name,pools);
 
        }
        public Transform SpawnObj(Transform objSpawn )
        {
            if (!poolDictionary.ContainsKey(objSpawn.name) || poolDictionary[objSpawn.name].Count == 0)
            {
                var go =  Instantiate(objSpawn,Vector3.zero, Quaternion.identity);
                go.gameObject.name = objSpawn.name;
                return go;
            }
            var objreturn = poolDictionary[objSpawn.name].Dequeue();
            objreturn.gameObject.transform.position = Vector3.zero;
            objreturn.gameObject.SetActive(true);
            return objreturn;
        }
    }

}

