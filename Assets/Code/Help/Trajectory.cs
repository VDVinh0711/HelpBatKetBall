
using UnityEngine;



namespace Lagger.Code.Trajectory
{
    public class Trajectory : MonoBehaviour
    {
        [SerializeField] int dotsNumber;
        [SerializeField] GameObject DotsParent;
        [SerializeField] GameObject DotsPerfab;
        [SerializeField] float dotSpacing;
        [SerializeField] [Range(0.01f, 0.5f)] float dotMinScale;
        [SerializeField] [Range(0.5f, 1f)] float dotMaxScale;
    
        Transform[] dotsList;
        Vector2 pos;
        float TimeStamp;
    
        private void Start()
        {
            Hide();
            prepareDots();
        }
    
    
        void prepareDots()
        {
            dotsList = new Transform[dotsNumber];
            DotsPerfab.transform.localScale = Vector3.one * dotMaxScale;
    
            float scale = dotMaxScale;
            float scalefactor = scale / dotsNumber;
    
            for(int i = 0; i < dotsNumber; i++)
            {
                dotsList[i] = Instantiate(DotsPerfab, null).transform;
                dotsList[i].parent = DotsParent.transform;
    
                dotsList[i].localScale = Vector3.one * scale;
                if(scale > dotMinScale)
                {
                    scale -= scalefactor;
                }
            }
        }
    
        public void UpDateDots(Vector3 ballPos , Vector2 forceApplied)
        {
            TimeStamp = dotSpacing;
            for(int i = 0; i < dotsNumber; i++)
            {
                pos.x = (ballPos.x + forceApplied.x * TimeStamp);
                pos.y = (ballPos.y + forceApplied.y * TimeStamp) - (Physics2D.gravity.magnitude * TimeStamp * TimeStamp) / 1.5f;
                dotsList[i].position = pos;
                TimeStamp += dotSpacing;
            }
        }
    
    
        public void Show()
        {
            DotsParent.SetActive(true);
        }
        public void Hide()
        {
            DotsParent.SetActive(false);
        }
    }
}

