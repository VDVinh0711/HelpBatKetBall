using Lagger.Code.TimeGame;
using TMPro;
using UnityEngine;


namespace Lagger.Code.UIInGame
{
    public class UI_TimeInGame : MonoBehaviour
    {
        [Header("ReferenceValue")]
        [SerializeField] private TimeInGame _tieTimeInGame;
        [Header("REF OBJ")]
        [SerializeField] private TextMeshProUGUI _textTime;


        private void Start()
        {
            SetUpBegin();
        }

        private void SetUpBegin()
        {
            _tieTimeInGame.ActionChangeTime -= UpDateUITime;
            _tieTimeInGame.ActionChangeTime += UpDateUITime;
        }
        
        private void UpDateUITime(int time)
        {
            int minute = time / 60;
            int second = time % 60;
            _textTime.SetText(minute + ":" + second);
        }
        
    }

}
