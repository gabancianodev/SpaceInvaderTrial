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
    }

    private void OnDestroy()
    {
        EventsManager.Instance.OnRocketHit -= OnRocketHit;
    }

    private void OnRocketHit(Rocket i_Rocket)
    {
        m_CurrentScore += m_EnemyHitScore;
        EventsManager.Instance.InvokeOnScoreUpdate(m_CurrentScore);
    }
}
