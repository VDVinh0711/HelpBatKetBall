
using TMPro;
using UnityEngine;
namespace  Lagger.Code.Spinner
{
    public class CheckReward : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _txtResult;
        public  void  CheckReWard(ItemSpinner[] contents , out ItemSpinner result ) 
        {
            int numberOfSlices = contents == null ? 0 : contents.Length;
            result = null;
            for(int i = 0; i<numberOfSlices;i++)
            {
                float startRotation = (360 / numberOfSlices) * i;
                float endRotation = (360 / numberOfSlices) * (i+1);
                if (transform.eulerAngles.z <= startRotation || transform.eulerAngles.z > endRotation) continue;
                result = contents[i];
              //  SetUpUiResutl(result);
            }
        }


        private void SetUpUiResutl(string result)
        {
            _txtResult.SetText(result);
        }
    }

}
