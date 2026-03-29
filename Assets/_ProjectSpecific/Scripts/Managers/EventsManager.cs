using System;
using UnityEngine;

public class EventsManager : MonoBehaviour
{
    public static EventsManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void DebugMessage(string i_EventName)
    {
#if UNITY_EDITOR
        Debug.Log(i_EventName + " event invoked.");
#endif
    }

    public event Action OnGameStart;

    public void InvokeOnGameStart()
    {
        OnGameStart?.Invoke();
        DebugMessage("OnGameStart");
    }

    
}
