using UnityEngine;

public class Ship : MonoBehaviour
{
    [Header("Main Ship Settings")]
    [SerializeField] private bool m_IsPlayer = false;
    [Space]
    [SerializeField] private int m_Life = 1;
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

    public int GetLife()
    {
        return m_Life;
    }

    public void TakeDamage(int i_Damage)
    {
        m_Life -= i_Damage;

        if(m_Life <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        if(m_IsPlayer)
        {
            EventsManager.Instance.InvokeOnPlayerDeath();
        }
    }
}
