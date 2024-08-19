using Cysharp.Threading.Tasks;
using System.Linq;
using Code.Helper;
using UnityEngine;

namespace Lagger.Code.Data
{
    public class DataManger : MonoBehaviour
    {
        private  async UniTask OnEnable()
        {
            await LoadData();
        }

        public void SaveData()
        {
            var dataSaves = gameObject.GetComponentsInChildren<ISaveData>().ToList();
            foreach (var data in dataSaves)
            {
                FireBaseManager.Instance.SaveData(data.GetType().ToString(),data.Save());
            }
        }
        public async UniTask LoadData()
        {
            var objLoadDatas = gameObject.GetComponentsInChildren<ISaveData>().ToList();
            foreach (var obj in objLoadDatas)
            {
                string key = Helper.GetLastPart(obj.GetType().ToString());
                obj.Load(  await FireBaseManager.Instance.LoadData(key));
                Debug.Log(await FireBaseManager.Instance.LoadData(key));
                
            }
        }
        private void OnDestroy()
        {
            SaveData();
        }
    }

}
