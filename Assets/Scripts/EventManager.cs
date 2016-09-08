using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

public enum EventName
{

}

public class EventManager : MonoBehaviour
{
    private static Dictionary<EventName, UnityEvent> eventDictionary;
    private static EventManager instance;
    public static EventManager Instance
    {
        get
        {
            if (instance == null)
            {
                Init();

                if (instance == null)
                {
                    Debug.LogError("You need an EventManager in your scene");
                }
            }
            return instance;
        }
    }

    static void Init()
    {
        if (instance == null)
        {
            instance = FindObjectOfType(typeof(EventManager)) as EventManager;
        }
        if (eventDictionary == null)
        {
            eventDictionary = new Dictionary<EventName, UnityEvent>();
        }
    }

    void Awake()
    {
        Init();
        DontDestroyOnLoad(this);
    }

    public static void StartListening(EventName eventName, UnityAction action)
    {
        if (instance == null)
        {
            Init();
        }
        UnityEvent thisEvent = null;
        if (eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent = new UnityEvent();
            thisEvent.AddListener(action);
            eventDictionary.Add(eventName, thisEvent);
        }
    }

    public static void StopListening(EventName eventName, UnityAction action)
    {
        if (instance == null)
        {
            return;
        }
        UnityEvent thisEvent = null;
        if (eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.RemoveListener(action);
        }
    }

    public static void TriggerEvent(EventName eventName)
    {
        UnityEvent thisEvent = null;
        if(eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.Invoke();
        }
    }
}