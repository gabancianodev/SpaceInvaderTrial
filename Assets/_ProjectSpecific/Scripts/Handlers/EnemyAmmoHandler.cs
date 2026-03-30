using System.Collections.Generic;
using UnityEngine;

public class EnemyAmmoHandler : MonoBehaviour
{
    [SerializeField] private List<EnemyRocket> m_EnemyRocketPool;
    [Space]
    [SerializeField] private Transform m_StoredEnemyRockets;
    [SerializeField] private Transform m_FiredRockets;

    [SerializeField] private Transform m_RocketSpawnPoint;
    private void Start()
    {
        EventsManager.Instance.OnGameStart += OnGameStart;
        EventsManager.Instance.OnEnemyFire += OnEnemyFire;
        EventsManager.Instance.OnEnemyRocketHit += OnEnemyRocketHit;
    }

    private void OnDestroy()
    {
        EventsManager.Instance.OnGameStart -= OnGameStart;
        EventsManager.Instance.OnEnemyFire -= OnEnemyFire;
        EventsManager.Instance.OnEnemyRocketHit -= OnEnemyRocketHit;
    }

    private void OnGameStart()
    {
        SetRocketsPosition();
    }

    private void SetRocketsPosition()
    {
        foreach (EnemyRocket i_EnemyRocket in m_EnemyRocketPool)
        {
            i_EnemyRocket.transform.localPosition = m_RocketSpawnPoint.localPosition;
        }
    }

    private void OnEnemyFire(Transform i_EnemyTransform)
    {
        if(m_EnemyRocketPool.Count <= 0)
        {
            return;
        }

        EnemyRocket rocketToFire = m_EnemyRocketPool[0];
        rocketToFire.gameObject.SetActive(true);
        m_EnemyRocketPool.RemoveAt(0);

        rocketToFire.transform.position = i_EnemyTransform.position;
        rocketToFire.transform.SetParent(m_FiredRockets);
        rocketToFire.SetIsFiredStatus(true);
    }

    private void OnEnemyRocketHit(EnemyRocket i_EnemyRocket)
    {
        if (m_EnemyRocketPool.Contains(i_EnemyRocket))
        {
            return; 
        }

        i_EnemyRocket.SetIsFiredStatus(false);
        i_EnemyRocket.gameObject.SetActive(false);

        i_EnemyRocket.transform.SetParent(m_StoredEnemyRockets);
        i_EnemyRocket.transform.localPosition = Vector3.zero;
        m_EnemyRocketPool.Add(i_EnemyRocket);
    }
}
