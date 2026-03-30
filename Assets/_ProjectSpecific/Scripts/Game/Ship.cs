using UnityEngine;

public class Ship : MonoBehaviour
{
    [Header("Main Ship Settings")]
    [SerializeField] private bool m_IsPlayer = false;
    [Space]
    [SerializeField] private float m_Speed = 5f;


    protected virtual void Fire()
    {
        EventsManager.Instance.InvokeOnPlayerFire(transform);
    }

    public bool GetPlayerStatus()
    {
        return m_IsPlayer;
    }

    public float GetSpeed()
    {
        return m_Speed;
    }

    protected virtual void Die()
    {
        if(m_IsPlayer)
        {
            EventsManager.Instance.InvokeOnPlayerDeath();
        }
    }
}
