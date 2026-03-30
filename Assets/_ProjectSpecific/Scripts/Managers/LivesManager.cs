using UnityEngine;

public class LivesManager : MonoBehaviour
{
    [Header("Lives Settings")]
    [SerializeField] private int m_CurrentLives = 5;

    private void Start()
    {
        EventsManager.Instance.OnGameStart += OnGameStart;
        EventsManager.Instance.OnEnemyRocketHit += OnEnemyRocketHit;
    } 

    private void OnDestroy()
    {
        EventsManager.Instance.OnGameStart -= OnGameStart;
        EventsManager.Instance.OnEnemyRocketHit -= OnEnemyRocketHit;
    }

    private void OnGameStart()
    {
        EventsManager.Instance.InvokeOnLivesUpdate(m_CurrentLives);
    }

    private void OnEnemyRocketHit(EnemyRocket i_EnemyRocket)
    {
        m_CurrentLives -= 1;
        EventsManager.Instance.InvokeOnLivesUpdate(m_CurrentLives);

        if(m_CurrentLives <= 0)
        {
            m_CurrentLives = 0;
            EventsManager.Instance.InvokeOnGameOver();
        }
    }
}