using System;
using System.Collections.Generic;
using System.Linq;
using Lagger.Code.User;
using UnityEngine;
namespace Lagger.Code.ItemHelper
{
    public class UpGradeItemBuff : MonoBehaviour
    {
       [SerializeField]  private List<ItemUpgrade> _listItemUpGrade = new();
       [SerializeField] private UserWallet _userWallet;

       public List<ItemUpgrade> ListItemUpGrade => _listItemUpGrade;
       private void OnEnable()
       {
           EventManger<ItemType>.Registerevent("UpGradeItem",UpGradeItem);
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
            
        }

       private void OnDisable()
       {
           EventManger<ItemType>.Removeevent("UpGradeItem",UpGradeItem);
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
            ActionUpGrade?.Invoke(itemConfig);
        }

        public bool CanUpGrade(int price )
        {
            bool result = false;
            result = price >= itemConfig.costToUpGrade ;
            return result;
        }

    }

}
