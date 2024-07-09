
using UnityEngine;
using Lagger.Code.Manager;
namespace Lagger.Code.Pit
{
    public class Pit : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _particleSystem;


        private void Start()
        {
            _particleSystem.Pause();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if(!other.gameObject.CompareTag("Player")) return;
            GameManager.Instance.Win();
            print("Win");
            _particleSystem.Play();
        }
    }

}
