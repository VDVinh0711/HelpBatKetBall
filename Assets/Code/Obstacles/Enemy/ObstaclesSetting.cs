
using UnityEngine;
namespace Lagger.Code.Obstacles
{
    [CreateAssetMenu(fileName = "Obstacles", menuName = "Obstacles/ObstaclesSetting")]
    public class ObstaclesSetting : ScriptableObject
    {  [SerializeField] private ObstacclesType _type;
       [SerializeField]  private int _damage;

       public ObstacclesType Type => _type;
       public int  Damage => _damage;
    }

}
