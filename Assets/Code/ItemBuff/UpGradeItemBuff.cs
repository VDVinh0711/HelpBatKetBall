using System;
using System.Collections.Generic;
using System.Linq;
using Lagger.Code.Data;
using Lagger.Code.Model;
using Lagger.Code.Untils;
using Lagger.Code.User;
using Newtonsoft.Json;
using NUnit.Framework;
using UnityEngine;
namespace Lagger.Code.ItemHelper
{
    public class UpGradeItemBuff : MonoBehaviour,ISaveData
    {
       [SerializeField]  private List<ItemUpgrade> _listItemUpGrade = new();
       [SerializeField] private UserWallet _userWallet;

       public List<ItemUpgrade> ListItemUpGrade => _listItemUpGrade;
       private void OnEnable()
       {
           EventManger<ItemType>.Registerevent(SafeNameEvent.UpGradeItem,UpGradeItem);
       }
       
       public void UpGradeItem(ItemType type)
        {
            var itemupgrade = _listItemUpGrade.FirstOrDefault(x => x.type == type);
            if(itemupgrade == null) return;
            if (itemupgrade.CanUpGrade(_userWallet.CurrentBalance))
            {
                itemupgrade.UpGrade();
                _userWallet.ReduceMoney(itemupgrade.itemConfig.costToUpGrade);
            }
            else
            {
                EventManger<string>.RaiseEvent(SafeNameEvent.ShowNotify,"You Don't Have Enought Money To UpGrade");
            }
            
        }

       private void OnDisable()
       {
           EventManger<ItemType>.Removeevent(SafeNameEvent.UpGradeItem,UpGradeItem);
       }


       
       public string Save()
       {
           List<ModelUpGrade> dataUpGradeSave = new();
           foreach (var itemUpgrade in _listItemUpGrade)
           {
               ModelUpGrade dataUpGrade = new ModelUpGrade(itemUpgrade.itemConfig.idItem, itemUpgrade.itemConfig.level,itemUpgrade.itemConfig.duration);
               dataUpGradeSave.Add(dataUpGrade);
           }

           return JsonConvert.SerializeObject(dataUpGradeSave);
       }

       public void Load(string obj)
       {
           print("data UpGrade");
           var dataLoads = JsonConvert.DeserializeObject<List<ModelUpGrade>>(obj);
           foreach (var dataLoad in dataLoads)
           {
               foreach (var itemUpgrade in _listItemUpGrade)
               {
                   if (itemUpgrade.itemConfig.idItem == dataLoad.idItemUpGrade)
                   {
                       itemUpgrade.LoadDataConfig(dataLoad);
                   }
               }
           }
       }
    }


    
    [System.Serializable]
    public class ItemUpgrade
    {
        public ItemConfig itemConfig;
        public ItemType type => itemConfig.itemType;
        public Action<ItemConfig> ActionUpGrade;
        public void UpGrade()
        {
            itemConfig.UpGrade();
            OnActionChangeUI();
        }

        public bool CanUpGrade(int price )
        {
            bool result = false;
            result = price >= itemConfig.costToUpGrade ;
            return result;
        }

        public void LoadDataConfig(ModelUpGrade modelUpGrade)
        {
            itemConfig.level = modelUpGrade.level;
            itemConfig.duration = modelUpGrade.duration;
          OnActionChangeUI();
        }

        private void OnActionChangeUI()
        {
            ActionUpGrade?.Invoke(itemConfig);
        }

    }

}
