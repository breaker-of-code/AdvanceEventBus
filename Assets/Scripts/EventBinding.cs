using System;
using AdvanceEventBus.Interfaces;

namespace AdvanceEventBus.Interfaces
{
    internal interface IEventBinding<T>
    {
        public Action<T> OnEvent { get; set; }
        public Action OnEventNoArgs { get; set; }
    }
}

namespace AdvanceEventBus.Classes
{
    public class EventBinding<T> : IEventBinding<T> where T : IEvent
    {
        Action<T> onEvent = _ => { };
        Action onEventNoArgs = () => { };
        
        Action<T> IEventBinding<T>.OnEvent
        {
            get => onEvent;
            set => onEvent = value;
        }
        
        Action IEventBinding<T>.OnEventNoArgs
        {
            get => onEventNoArgs;
            set => onEventNoArgs = value;
        }

        public EventBinding(Action<T> onEvent) => this.onEvent = onEvent;
        public EventBinding(Action onEventNoArgs) => this.onEventNoArgs = onEventNoArgs;
        
        public void AddEvent(Action<T> onEvent) => this.onEvent += onEvent;
        public void RemoveEvent(Action<T> onEvent) => this.onEvent -= onEvent;
        
        public void AddEvent(Action onEventNoArgs) => this.onEventNoArgs += this.onEventNoArgs;
        public void RemoveEvent(Action onEventNoArgs) => this.onEventNoArgs -= onEventNoArgs;
    }
}