using System;

namespace Code.Utils.Timer
{
    public abstract class Timer {
        public float InitialTime;
        public float Time { get; set; }
        public bool IsRunning { get; protected set; }
        
        public float Progress => Time / InitialTime;
        
        public Action OnTimerStart = delegate { };
        public Action OnTimerStop = delegate { };
        public Action OnTimeRunning = delegate { };
        public Action<float> ActionChangeTime;

        protected Timer(float value) {
            InitialTime = value;
            IsRunning = false;
        }

        public void Start() {
            Time = InitialTime;
            if (IsRunning) return;
            IsRunning = true;
            OnTimerStart.Invoke();
        }

        public void Stop()
        {
            if (!IsRunning) return;
            IsRunning = false;
            OnTimerStop.Invoke();
        }
        
        
        public void Resume() => IsRunning = true;
        public void Pause() => IsRunning = false;

        public virtual void Tick(float deltaTime)
        {
            OnTimeRunning?.Invoke();
            ActionChangeTime?.Invoke(Time);
        }
    }
}