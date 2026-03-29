using UnityEngine;

public class EnemyRocket : Rocket
{
    protected override void OnCollisionEnter(Collision i_Object)
    {
        if(i_Object.gameObject.CompareTag("Player") || i_Object.gameObject.CompareTag("EndArea"))
        {
            NotifyHit();
        }

        if(i_Object.gameObject.CompareTag("Player"))
        {
            //i_Object.gameObject.SetActive(false);
        }
    }
    protected override void NotifyHit()
    {
        EventsManager.Instance.InvokeOnEnemyRocketHit(this);
    }
}
