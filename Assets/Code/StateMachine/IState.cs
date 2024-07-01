namespace Code.StateMachine
{
    public interface IState 
    {
        void OnEnter();
        void Update();
        void FixedUpdate();
        void OnExit();
    }
}
