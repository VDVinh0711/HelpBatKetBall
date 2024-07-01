using UnityEngine;
namespace Lagger.Code.ItemHelper
{
    
    [CreateAssetMenu(fileName = "ItemHelp",menuName  = "ItemHelp/Item")]
    public class ItemConfig : ScriptableObject
    {
        public ItemType itemType;
        public int value;
        public int duration;
        public Sprite sprite;
    }

}
