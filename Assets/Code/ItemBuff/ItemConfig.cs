using UnityEngine;
namespace Lagger.Code.ItemHelper
{
    [CreateAssetMenu(fileName = "ItemHelp",menuName  = "ItemHelp/Item")]
    public class ItemConfig : ScriptableObject
    {
        [SerializeField] private int _baseValue;
        [SerializeField] private int _baseCostUpGrade;
        public const int maxLevel = 10;
        public ItemType itemType;
        public int value  => _baseValue * level;
        public int duration;
        public Sprite sprite;
        public int level = 1;
        [Tooltip("The description will replace the character ! with the value and the character $ with the duration of the action")]
        public string des;
        public int costToUpGrade => _baseCostUpGrade * (level/2);
        
        public string GetDes()
        {
            return des.Replace("#",level+"").Replace("!", value+"").Replace("$", duration + "");
        }

        public void UpGrade()
        {
            if(level >= maxLevel) return;
            level++;
            duration++;
            if (level >= maxLevel) level = maxLevel;
        }
    }
}
