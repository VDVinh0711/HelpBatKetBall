
using Code.Helper;
using Lagger.Code.TimeGame;
using UnityEngine;
using UnityEngine.UI;


namespace Lagger.Code.UIInGame
{
    public class UI_StarIngame : MonoBehaviour
    {

        [SerializeField] private Image[] _stars = new Image[3];
        [SerializeField] private TimeInGame _timeInGame;


        private void Start()
        {
            _timeInGame.ActionChangeTime -= ChangTime;
            _timeInGame.ActionChangeTime += ChangTime;
        }

        private void ChangTime(int time)
        {
            int star = Helper.CaculateStar(_timeInGame.timelimit, time);
            UpdateStar(star);
        }

    private void UpdateStar(int numberStar)
        {
            for (int i = 0; i < 3; i++)
            {
                if (i <= (numberStar - 1))
                {
                    _stars[i].enabled = true;
                    continue;
                }
                _stars[i].enabled = false;
            }
        }


    public void ResetStar()
    {
        for (int i = 0; i < 3; i++)
        {
            _stars[i].enabled = true;
        }
    }
    }
    

}
