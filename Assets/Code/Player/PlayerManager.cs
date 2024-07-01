using Lagger.Code.Level;
using UnityEngine;

namespace  Lagger.Code.Player
{
    public class PlayerManager : MonoBehaviour
    {
        private Transform _lastPlatColi;
        private void OnEnable()
        {
            EventManager.RegisterEvent("ResposPlayer",ResPlayer);
            EventManger<Vector2>.Registerevent("SetPosPlayer",SetPosPlayer);
            EventManager.RegisterEvent("DeActivePlayer",DeActivePlayer);
        }

        public void SetPosPlayer(Vector2 position)
        {
            transform.position = position;
        }
        public void ResPlayer()
        { 
            Vector2 posSet = _lastPlatColi != null ? new Vector2(_lastPlatColi.position.x,_lastPlatColi.position.y+2.0f) : LevelManager.Instance.GetPosSpawnPlayer();
            SetPosPlayer(posSet);
        }

        public void SetLastPlatFormColi(Transform platform)
        {
            _lastPlatColi = platform;
        }
        
        public void ActivePlayer()
        {
            gameObject.SetActive(true);
        }

        public void DeActivePlayer()
        {
            gameObject.SetActive(false);
        }
        
        private void OnDisable()
        {
            EventManager.RemoveListener("ResposPlayer",ResPlayer);
            EventManger<Vector2>.Removeevent("SetPosPlayer",SetPosPlayer);
        }
    }

}
