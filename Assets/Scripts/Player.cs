using System;
using AdvanceEventBus.Classes;
using UnityEngine;

public class Player : MonoBehaviour
{
    // private int health;
    // private int mana;

    private EventBinding<TestEvent> testEventBinding;
    private EventBinding<PlayerEvent> playerEventBinding;

    // private void Awake()
    // {
    //     health = 100;
    //     mana = 10;
    // }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            EventBus<TestEvent>.RaiseEvent(new TestEvent());
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            EventBus<PlayerEvent>.RaiseEvent(new PlayerEvent()
            {
                health = 97,
                mana = 45,
            });
        }
    }

    void HandleTestEvent()
    {
        Debug.Log($"break-of-code: received test event;");
    }

    void HandlePlayerEvent(PlayerEvent playerEvent)
    {
        Debug.Log($"break-of-code: player event received, health: {playerEvent.health} :: mana: {playerEvent.mana};");
    }

    private void OnEnable()
    {
        testEventBinding = new EventBinding<TestEvent>(HandleTestEvent);
        EventBus<TestEvent>.RegisterEvent(testEventBinding);
        
        playerEventBinding = new EventBinding<PlayerEvent>(HandlePlayerEvent);
        EventBus<PlayerEvent>.RegisterEvent(playerEventBinding);
    }
    
    private void OnDisable()
    {
        EventBus<TestEvent>.DeRegisterEvent(testEventBinding);
        EventBus<PlayerEvent>.DeRegisterEvent(playerEventBinding);
    }
}