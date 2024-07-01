
using System;
using UnityEngine;


namespace Lagger.Code.Camere
{
    public class CameraFollowPlayer : MonoBehaviour
    {
        [SerializeField] private Transform _player;
        [SerializeField] private float _speedMove;
        private float height;
        private float width;

        private void Start()
        {
            Camera camera = Camera.main;
            height = 2f * camera.orthographicSize;
            width = height * camera.aspect;
        }

        private void Update()
        {
            MoveFollowPLayer();
        }

        private void MoveFollowPLayer()
        {
            if(!_player.gameObject.activeSelf) return;
            if((height/2) >= GetDistanceCameAndPlay() && transform.position.y >= _player.position.y) return;
            Vector3 campos = new Vector3(transform.position.x, transform.position.y, -10);
            Vector3 playerpos = new Vector3(_player.position.x, _player.position.y, -10);
            transform.position = Vector3.Lerp(campos,playerpos,_speedMove * Time.smoothDeltaTime);
            
        }
        private float GetDistanceCameAndPlay()
        {
            return Vector3.Distance(_player.position, transform.position);
        }
    }

}
