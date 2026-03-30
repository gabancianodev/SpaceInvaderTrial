using UnityEngine;

public class Rocket : MonoBehaviour
{
    [Header("Rocket Settings")]
    [SerializeField] public bool m_IsFired = false;
    [Space]
    [SerializeField] public float m_RocketSpeed = 50f;
    [SerializeField] private Rigidbody m_RocketRigidbody;

    protected virtual void Update()
    {
        if (m_IsFired)
        {
            m_RocketRigidbody.MovePosition(transform.position + Vector3.forward * Time.deltaTime * m_RocketSpeed);
        }
    }

    public void SetIsFiredStatus(bool i_Status)
    {
        m_IsFired = i_Status;
    }

    protected virtual void OnCollisionEnter(Collision i_Object)
    {
        if(i_Object.gameObject.CompareTag("EndArea"))
        {
            m_IsFired = false;
            EventsManager.Instance.InvokeOnRocketHit(this, false);
        }

        if(i_Object.gameObject.CompareTag("Enemy"))
        {
            EventsManager.Instance.InvokeOnRocketHit(this, true);
            i_Object.gameObject.SetActive(false);
        }
    }

    protected virtual void NotifyHit()
    {
        EventsManager.Instance.InvokeOnRocketHit(this);
    }
}
