using System.Collections.Generic;
using System.Linq;
using UnityEngine;
namespace Lagger.Code.ItemHelper
{
    public class UpGradeItemBuff : MonoBehaviour
    {
       [SerializeField]  private List<ItemUpgrade> _listItemUpGrade = new();
        public void UpGrade(ItemType type, int price, out int reprice)
        {
            reprice = 0;
            var itemupgrade = _listItemUpGrade.FirstOrDefault(x => x.type == type);
            if(itemupgrade == null) return;
            if (itemupgrade.CanUpGrade(price, out reprice))
            {
                itemupgrade.UpGrade();
            }
            
        }

        public void Test()
        {
            UpGrade(ItemType.Shield , 10,out int pricereturn);
            print(pricereturn);
        }
    }


    
    [System.Serializable]
    public class ItemUpgrade
    {
        private const int baseCoseUpGreade = 12;
        private const int maxlevel = 10;
        [SerializeField] private int _currentLevel = 1;
        public ItemConfig _itemConfig;
        public ItemType type => _itemConfig.itemType;
        public void UpGrade()
        {
            _currentLevel++;
            int baseValue = _itemConfig.value;
            int baseDuration = _itemConfig.duration;
            _itemConfig.value = baseValue * _currentLevel;
            _itemConfig.duration = baseDuration * _currentLevel;
        }

        public bool CanUpGrade(int price , out int pricepre)
        {
            pricepre = price;
            bool result = false;
            result = price >= baseCoseUpGreade * _currentLevel;
            if (result) pricepre = price - (baseCoseUpGreade * _currentLevel);
            return result;
        }

    }

}
