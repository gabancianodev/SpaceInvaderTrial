using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [Header("Score Settings")]
    [SerializeField] private int m_CurrentScore = 0;
    [Space]
    [SerializeField] private int m_EnemyHitScore = 200;

    private void Start()
    {
        EventsManager.Instance.OnRocketHit += OnRocketHit;
        EventsManager.Instance.OnGameWon += OnGameWon;
    }

    private void OnDestroy()
    {
        EventsManager.Instance.OnRocketHit -= OnRocketHit;
        EventsManager.Instance.OnGameWon -= OnGameWon;
    }

    private void OnRocketHit(Rocket i_Rocket, bool i_IsEnemyHit)
    {
        if (i_IsEnemyHit)
        {
            m_CurrentScore += m_EnemyHitScore;
            EventsManager.Instance.InvokeOnScoreUpdate(m_CurrentScore);
        }
    }

    private void OnGameWon(int i_FinalScore)
    {
        m_CurrentScore = i_FinalScore;
        EventsManager.Instance.InvokeOnScoreUpdate(m_CurrentScore);
    }

}
