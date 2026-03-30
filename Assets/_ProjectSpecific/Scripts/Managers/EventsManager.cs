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

    public event Action OnAppStart;
    public void InvokeOnAppStart()
    {
        OnAppStart?.Invoke();
        DebugMessage("OnAppStart");
    }

    public event Action OnGameStart;

    public void InvokeOnGameStart()
    {
        OnGameStart?.Invoke();
        DebugMessage("OnGameStart");
    }

    public event Action<int> OnGameWon;

    public void InvokeOnGameWon(int i_FinalScore)
    {
        OnGameWon?.Invoke(i_FinalScore);
        DebugMessage("OnGameWon");
    }
    
    public event Action OnGameOver;

    public void InvokeOnGameOver()
    {
        OnGameOver?.Invoke();
        DebugMessage("OnGameOver");
    }

    #region PLAYER EVENTS

    public event Action<Transform> OnPlayerFire;

    public void InvokeOnPlayerFire(Transform i_Transform)
    {
        OnPlayerFire?.Invoke(i_Transform);
        DebugMessage("OnPlayerFire");
    }

    public event Action OnPlayerHit;
    public void InvokeOnPlayerHit()
    {
        OnPlayerHit?.Invoke();
        DebugMessage("OnPlayerHit");
    }

    public event Action OnPlayerDeath;

    public void InvokeOnPlayerDeath()
    {
        OnPlayerDeath?.Invoke();
        DebugMessage("OnPlayerDeath");
    }

    #endregion

    #region ENEMY EVENTS
    public event Action<Transform> OnEnemyFire;

    public void InvokeOnEnemyFire(Transform i_Transform)
    {
        OnEnemyFire?.Invoke(i_Transform);
        DebugMessage("OnEnemyFire");
    }
    #endregion

    #region GAME EVENTS
    public event Action<Rocket, bool> OnRocketHit;

    public void InvokeOnRocketHit(Rocket i_Rocket, bool i_IsEnemyHit = false)
    {
        OnRocketHit?.Invoke(i_Rocket, i_IsEnemyHit);
        DebugMessage("OnRocketHit", "Rocket: " + i_Rocket.name);
    }

    public event Action<Transform> OnParticleExplosion;

    public void InvokeOnParticleExplosion(Transform i_ParticleTransform)
    {
        OnParticleExplosion?.Invoke(i_ParticleTransform);
        DebugMessage("OnParticleExplosion");
    }

    public event Action<EnemyRocket, bool> OnEnemyRocketHit;
    public void InvokeOnEnemyRocketHit(EnemyRocket i_EnemyRocket, bool i_IsPlayerHit = false)
    {
        OnEnemyRocketHit?.Invoke(i_EnemyRocket, i_IsPlayerHit);
        DebugMessage("OnEnemyRocketHit", "Enemy Rocket: " + i_EnemyRocket.name);
    }
    #endregion

    #region UI EVENTS
    public event Action<int> OnScoreUpdate;
    public void InvokeOnScoreUpdate(int i_NewScore)
    {
        OnScoreUpdate?.Invoke(i_NewScore);
        DebugMessage("OnScoreUpdate", "New Score: " + i_NewScore);
    }

    public event Action<int> OnLivesUpdate;
    public void InvokeOnLivesUpdate(int i_NewLives)
    {
        OnLivesUpdate?.Invoke(i_NewLives);
        DebugMessage("OnLivesUpdate", "New Lives: " + i_NewLives);
    }
    #endregion
}
