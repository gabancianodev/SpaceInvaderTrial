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

    private void DebugMessage(string i_EventName, string i_Parameters = "")
    {
#if UNITY_EDITOR
        Debug.Log("<color=lightblue><b>" + i_EventName + " event invoked.</b></color>");
#endif
    }

    public event Action OnGameStart;

    public void InvokeOnGameStart()
    {
        OnGameStart?.Invoke();
        DebugMessage("OnGameStart");
    }

    #region PLAYER EVENTS

    public event Action<Transform> OnPlayerFire;

    public void InvokeOnPlayerFire(Transform i_Transform)
    {
        OnPlayerFire?.Invoke(i_Transform);
        DebugMessage("OnPlayerFire");
    }

    public event Action OnPlayerDeath;

    public void InvokeOnPlayerDeath()
    {
        OnPlayerDeath?.Invoke();
        DebugMessage("OnPlayerDeath");
    }

    #endregion

    #region GAME EVENTS
    public event Action<Rocket> OnRocketHit;

    public void InvokeOnRocketHit(Rocket i_Rocket)
    {
        OnRocketHit?.Invoke(i_Rocket);
        DebugMessage("OnRocketHit", "Rocket: " + i_Rocket.name);
    }

    #endregion
}
