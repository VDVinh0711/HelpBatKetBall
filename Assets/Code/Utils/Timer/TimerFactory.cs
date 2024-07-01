using System;
using System.Collections.Generic;

namespace Code.Utils.Timer
{
    public class TimerFactory
    {
        private Dictionary<Type, Func<float, Timer>> _creators = new();

        public TimerFactory()
        {
            _creators[typeof(CountdownTimer)] = (duration) => new CountdownTimer(duration);
            _creators[typeof(StopwatchTimer)] = (_) => new StopwatchTimer();
        }

        public Timer CreateTimer(Type timerType, float duration)
        {
            if (_creators.TryGetValue(timerType, out var creator))
            {
                return creator(duration);
            }
            
            throw new ArgumentException($"Invalid timer type: {timerType}");
        }
    }
}