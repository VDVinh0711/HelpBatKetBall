
using System.Collections.Generic;
using System.Linq;

using Newtonsoft.Json;
using UnityEngine;

namespace Lagger.Code.Data
{
    public class DataManger : MonoBehaviour
    {
        private void Start()
        {
            SaveData();
        }

        public void SaveData()
        {
            var dataSaves = gameObject.GetComponentsInChildren<ISaveData>().ToList();
            Dictionary<string, string> _dataSaves = new();
            foreach (var data in dataSaves)
            {
                _dataSaves[data.GetType().ToString()] = data.Save();
            }
            var dataJson = JsonConvert.SerializeObject(_dataSaves);
            //PusJson Into firebase
        }

        public void LoadData(string dataJson)
        {
            //LoadJson From FireBase
            // string dataJson =
            //     "{\"Lagger.Code.Level.LevelManager\":\"[{\\\"idLevel\\\":0,\\\"starOfLevel\\\":0},{\\\"idLevel\\\":0,\\\"starOfLevel\\\":0}]\",\"Lagger.Code.User.UserManager\":\"{\\\"money\\\":10000,\\\"dimond\\\":10000}\",\"Lagger.Code.ItemHelper.UpGradeItemBuff\":\"[{\\\"idItemUpGrade\\\":\\\"heal\\\",\\\"level\\\":2,\\\"duration\\\":18},{\\\"idItemUpGrade\\\":\\\"Shield\\\",\\\"level\\\":100,\\\"duration\\\":200}]\"}";
            var dataLoads = JsonConvert.DeserializeObject<Dictionary<string, string>>(dataJson);
            var objLoadDatas = gameObject.GetComponentsInChildren<ISaveData>().ToList();
            foreach (var obj in objLoadDatas)
            {
                string typeObj = obj.GetType().ToString();
                if (dataLoads.ContainsKey(typeObj))
                {
                    obj.Load(dataLoads[typeObj]);
                }
            
            }
        }


        // private void OnDestroy()
        // {
        //     SaveData();
        // }


        

       
    }

}
