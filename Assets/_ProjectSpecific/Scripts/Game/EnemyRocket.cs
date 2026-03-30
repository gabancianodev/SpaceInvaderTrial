using UnityEngine;

public class EnemyRocket : Rocket
{
    [SerializeField] private Rigidbody m_EnemyRocketRigidbody;
    
    protected override void Update()
    {
        m_EnemyRocketRigidbody.MovePosition(transform.position + Vector3.back * Time.deltaTime * m_RocketSpeed);
    }

    protected override void OnCollisionEnter(Collision i_Object)
    {
        if(i_Object.gameObject.CompareTag("Player") || i_Object.gameObject.CompareTag("EndArea"))
        {
            NotifyHit();
        }

        if(i_Object.gameObject.CompareTag("Player"))
        {
            
        }
    }
    protected override void NotifyHit()
    {
        EventsManager.Instance.InvokeOnEnemyRocketHit(this);
    }
}
