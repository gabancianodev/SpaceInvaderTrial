using UnityEngine;

public class ParticleHandler : MonoBehaviour
{
    [Header("Particle Settings")]
    [SerializeField] private ParticleSystem m_ExplosionParticle;

    private void Start()
    {
        EventsManager.Instance.OnRocketHit += OnRocketHit;
        EventsManager.Instance.OnEnemyRocketHit += OnEnemyRocketHit;
    }

    private void OnDestroy()
    {
        EventsManager.Instance.OnRocketHit -= OnRocketHit;
        EventsManager.Instance.OnEnemyRocketHit -= OnEnemyRocketHit;
    }

    private void OnRocketHit(Rocket i_Rocket, bool i_IsEnemyHit)
    {
        if (i_IsEnemyHit)
        {
            ExplodeParticle(i_Rocket.transform);
        }
    }

    private void OnEnemyRocketHit(EnemyRocket i_EnemyRocket, bool i_IsPlayerHit)
    {
        if (i_IsPlayerHit)
        {
            ExplodeParticle(i_EnemyRocket.transform);
        }
    }

    private void ExplodeParticle(Transform i_ParticlePosition)
    {
        m_ExplosionParticle.transform.position = i_ParticlePosition.position;
        m_ExplosionParticle.Play();
    }
}
