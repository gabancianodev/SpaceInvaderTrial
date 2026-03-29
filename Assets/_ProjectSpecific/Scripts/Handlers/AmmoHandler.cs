using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class AmmoHandler : MonoBehaviour
{
    [Header("Ammo Dispenser Settings")]
    [SerializeField] private float m_RocketCooldown = 1f;
    [SerializeField] private bool m_IsOnCooldown = false;
    [Space]
    [SerializeField] private List<Rocket> m_RocketPool;
    [SerializeField] private List<EnemyRocket> m_EnemyRocketPool;
    
    [SerializeField] private Transform m_RocketSpawnPoint;
    [SerializeField] private Transform m_StoredRockets;
    [SerializeField] private Transform m_StoredEnemyRockets;
    [SerializeField] private Transform m_FiredRockets;

    Coroutine cooldownCoroutine;
    
    private void Start()
    {
        EventsManager.Instance.OnGameStart += OnGameStart;
        EventsManager.Instance.OnPlayerFire += OnPlayerFire;
        EventsManager.Instance.OnEnemyFire += OnEnemyFire;
        EventsManager.Instance.OnRocketHit += OnRocketHit;
        EventsManager.Instance.OnEnemyRocketHit += OnEnemyRocketHit;
    }

    private void OnDestroy()
    {
        EventsManager.Instance.OnGameStart -= OnGameStart;
        EventsManager.Instance.OnPlayerFire -= OnPlayerFire;
        EventsManager.Instance.OnEnemyFire -= OnEnemyFire;
        EventsManager.Instance.OnRocketHit -= OnRocketHit;
        EventsManager.Instance.OnEnemyRocketHit -= OnEnemyRocketHit;
    }

    private IEnumerator RocketCooldown()
    {
        yield return new WaitForSeconds(m_RocketCooldown);

        m_IsOnCooldown = false;
    }

    private void OnGameStart()
    {
        SetRocketsPosition();
    }

    private void OnPlayerFire(Transform i_PlayerTransform)
    { 

        if(m_IsOnCooldown || m_RocketPool.Count <= 0)
        {
            return;
        }

        ReadyRocket(i_PlayerTransform);
        FireRocket(true);

        m_IsOnCooldown = true;
        cooldownCoroutine = StartCoroutine(RocketCooldown());
    }

    private void OnEnemyFire(Transform i_EnemyTransform)
    {
        if(m_EnemyRocketPool.Count <= 0)
        {
            return;
        }

        ReadyEnemyRocket(i_EnemyTransform);
        FireRocket(false);
    }

    private void OnRocketHit(Rocket i_Rocket)
    {
        i_Rocket.transform.localPosition = m_RocketSpawnPoint.localPosition;
        i_Rocket.transform.SetParent(m_StoredRockets);
        m_RocketPool.Add(i_Rocket);
    }

    private void OnEnemyRocketHit(EnemyRocket i_EnemyRocket)
    {
        i_EnemyRocket.transform.localPosition = m_RocketSpawnPoint.localPosition;
        i_EnemyRocket.transform.SetParent(m_StoredEnemyRockets);
        m_EnemyRocketPool.Add(i_EnemyRocket);
    }

    private void SetRocketsPosition()
    {
        foreach (Rocket i_Rocket in m_RocketPool)
        {
            i_Rocket.transform.localPosition = m_RocketSpawnPoint.localPosition;
        }

        foreach (EnemyRocket i_EnemyRocket in m_EnemyRocketPool)
        {
            i_EnemyRocket.transform.localPosition = m_RocketSpawnPoint.localPosition;
        }
    }

    public void ReadyRocket(Transform i_Transform)
    {
        m_RocketPool[0].transform.position = i_Transform.position;
    }

    public void ReadyEnemyRocket(Transform i_Transform)
    {
        m_EnemyRocketPool[0].transform.position = i_Transform.position;
    }

    public void FireRocket(bool i_IsPlayer)
    {
        if(i_IsPlayer)
        {
            if (m_RocketPool.Count <= 0)
            {
                return;
            }

            m_RocketPool[0].SetIsFiredStatus(true);

            m_RocketPool[0].transform.SetParent(m_FiredRockets);
            m_RocketPool.RemoveAt(0);

            if(cooldownCoroutine != null)
            {
                StopCoroutine(cooldownCoroutine);
            }
        }
        else
        {
            if (m_EnemyRocketPool.Count <= 0)
            {
                return;
            }
    
            m_EnemyRocketPool[0].SetIsFiredStatus(true);
    
            m_EnemyRocketPool[0].transform.SetParent(m_FiredRockets);
            m_EnemyRocketPool.RemoveAt(0);
        }
    }

    
}
