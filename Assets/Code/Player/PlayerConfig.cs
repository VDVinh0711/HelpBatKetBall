using Sirenix.OdinInspector;
using UnityEngine;

namespace Code.Player
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Player/PlayerConfig")]
    public class PlayerConfig : SerializedScriptableObject
    {
        [Header("Player Fly Settings")] 
        [SerializeField] private int _flyAngleRight = 70;
        [SerializeField] private int _flyAngleLeft = 110;
        [SerializeField, Range(2000, 3000)] private float _flyForceOnGround = 10000f;
        [SerializeField, Range(700, 1000)] private float _flyForceInAir = 250f;
        [SerializeField] private float _flyTouchDuration = 1;
        [SerializeField] private float _flyCooldown = 0.3f;
        [SerializeField] private float _gravityScale = 1.5f;
        [SerializeField] private float _flyForceMultiplierUnder20Percent = 1f;
        [SerializeField] private float _flyForceMultiplierUnder40Percent = 1.2f;
        [SerializeField] private float _flyForceMultiplierUnder60Percent = 1.4f;
        [SerializeField] private float _flyForceMultiplierUnder80Percent = 1.6f;
        [SerializeField] private float _flyForceMultiplierUnder100Percent = 1.8f;
        
        [Header("Player Strafe Settings")]
        [SerializeField] private float _strafeSpeed = 125f;
        
        public int FlyAngleRight => _flyAngleRight;
        public int FlyAngleLeft => _flyAngleLeft;
        public float FlyForceOnGround => _flyForceOnGround;
        public float FlyForceInAir => _flyForceInAir;
        public float FlyTouchDuration => _flyTouchDuration;
        public float FlyCooldown => _flyCooldown;
        public float GravityScale => _gravityScale;
        public float FlyForceMultiplierUnder20Percent => _flyForceMultiplierUnder20Percent;
        public float FlyForceMultiplierUnder40Percent => _flyForceMultiplierUnder40Percent;
        public float FlyForceMultiplierUnder60Percent => _flyForceMultiplierUnder60Percent;
        public float FlyForceMultiplierUnder80Percent => _flyForceMultiplierUnder80Percent;
        public float FlyForceMultiplierUnder100Percent => _flyForceMultiplierUnder100Percent;
        public float StrafeSpeed => _strafeSpeed;
    }
}
