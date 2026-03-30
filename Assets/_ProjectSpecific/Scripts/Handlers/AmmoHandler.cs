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
    
    [SerializeField] private Transform m_RocketSpawnPoint;
    [SerializeField] private Transform m_StoredRockets;
    [SerializeField] private Transform m_FiredRockets;

    Coroutine cooldownCoroutine;
    
    private void Start()
    {
        EventsManager.Instance.OnGameStart += OnGameStart;
        EventsManager.Instance.OnPlayerFire += OnPlayerFire;
        EventsManager.Instance.OnRocketHit += OnRocketHit;
    }

    private void OnDestroy()
    {
        EventsManager.Instance.OnGameStart -= OnGameStart;
        EventsManager.Instance.OnPlayerFire -= OnPlayerFire;
        EventsManager.Instance.OnRocketHit -= OnRocketHit;
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

        Rocket rocketToFire = m_RocketPool[0];
        rocketToFire.gameObject.SetActive(true);
        m_RocketPool.RemoveAt(0);

        rocketToFire.transform.position = i_PlayerTransform.position;
        rocketToFire.transform.SetParent(m_FiredRockets);
        rocketToFire.SetIsFiredStatus(true);

        m_IsOnCooldown = true;
        cooldownCoroutine = StartCoroutine(RocketCooldown());
    }

    

    private void OnRocketHit(Rocket i_Rocket)
    {
        i_Rocket.gameObject.SetActive(false);
        i_Rocket.SetIsFiredStatus(false);
        i_Rocket.transform.localPosition = m_RocketSpawnPoint.localPosition;
        i_Rocket.transform.SetParent(m_StoredRockets);
        m_RocketPool.Add(i_Rocket);
    }

    

    private void SetRocketsPosition()
    {
        foreach (Rocket i_Rocket in m_RocketPool)
        {
            i_Rocket.transform.localPosition = m_RocketSpawnPoint.localPosition;
        }
    }

    public void ReadyRocket(Transform i_Transform)
    {
        m_RocketPool[0].transform.position = i_Transform.position;
    }

    

    public void FireRocket()
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
}
