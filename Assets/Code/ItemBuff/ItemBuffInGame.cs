
using Lagger.Code.Pooling;
using UnityEngine;


namespace Lagger.Code.ItemHelper
{
    public  class ItemBuffInGame : MonoBehaviour
    {
        
        [SerializeField] private ItemConfig _itemconfig;
        public ItemType type => _itemconfig.itemType;
        public int value => _itemconfig.value;
        public int duration => _itemconfig.duration;
        public Sprite Sprite => _itemconfig.sprite;
        
        //UI
        private SpriteRenderer _spriteRenderer;

        private void Start()
        {
            SetUpBegin();
        }

        private void SetUpBegin()
        {
            _spriteRenderer = gameObject.GetComponentInChildren<SpriteRenderer>();
            SetUpUi();
        }

        private void SetUpUi()
        {
            _spriteRenderer.sprite = _itemconfig.sprite;
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if(!other.gameObject.CompareTag("Player")) return;
            PoolingObject.Instance.DeSpawnObj(this.transform);
        }

    }

}
