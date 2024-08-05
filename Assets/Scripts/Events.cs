using AdvanceEventBus.Interfaces;

namespace AdvanceEventBus.Interfaces
{
    public interface IEvent
    {
    }
}

namespace AdvanceEventBus.Classes
{
    public struct TestEvent : IEvent
    {
    }

    public struct PlayerEvent : IEvent
    {
        public int health;
        public int mana;
    }
}