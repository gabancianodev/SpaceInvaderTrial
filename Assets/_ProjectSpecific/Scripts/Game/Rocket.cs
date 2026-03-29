using UnityEngine;

public class Rocket : MonoBehaviour
{
    [Header("Rocket Settings")]
    [SerializeField] private bool m_IsFired = false;
    [Space]
    [SerializeField] private float m_RocketSpeed = 50f;
    [SerializeField] private Rigidbody m_RocketRigidbody;



    // Update is called once per frame
    private void Update()
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

    private void OnCollisionEnter(Collision i_Object)
    {
        if(i_Object.gameObject.CompareTag("Enemy") || i_Object.gameObject.CompareTag("EndArea"))
        {
            m_IsFired = false;
            EventsManager.Instance.InvokeOnRocketHit(this);

        }

        if(i_Object.gameObject.CompareTag("Enemy"))
        {
            i_Object.gameObject.SetActive(false);
        }
    }
}
