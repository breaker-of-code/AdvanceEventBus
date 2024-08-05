using System.Collections.Generic;
using AdvanceEventBus.Interfaces;

namespace AdvanceEventBus.Classes
{
    public static class EventBus<T> where T : IEvent
    {
        private static readonly HashSet<IEventBinding<T>> bindings = new HashSet<IEventBinding<T>>();

        public static void RegisterEvent(EventBinding<T> binding) => bindings.Add(binding);
        public static void DeRegisterEvent(EventBinding<T> binding) => bindings.Remove(binding);

        public static void RaiseEvent(T @event)
        {
            foreach (var binding in bindings)
            {
                binding.OnEvent.Invoke(@event);
                binding.OnEventNoArgs.Invoke();
            }
        }
    }
}