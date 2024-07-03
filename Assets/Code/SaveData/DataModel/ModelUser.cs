

namespace  Lagger.Code.Model
{
    [System.Serializable]
    public class ModelUser
    {
        public int money;
        public int dimond;

        public ModelUser(){}
        public ModelUser(int money, int dimond)
        {
            this.money = money;
            this.dimond = dimond;
        }
    }

}

