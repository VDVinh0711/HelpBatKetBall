


using UnityEngine;


namespace  Lagger.Code.Obstacles
{
    [RequireComponent(typeof(Collider2D))]
    public   class BaseObstacles : MonoBehaviour
    {
        protected Rigidbody2D rg;
        protected Collider coli;
        [SerializeField] protected ObstaclesSetting obstaclesConfig;
        public int DamageGive => obstaclesConfig == null ? 0 :  obstaclesConfig.Damage;
        
        private void Awake()
        {
            LoadComponent();
        }
        private void LoadComponent()
        {
            rg = gameObject.GetComponent<Rigidbody2D>();
            coli = gameObject.GetComponent<Collider>();
        }
       
      
    }

}
