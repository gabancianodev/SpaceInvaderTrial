using DG.Tweening;
using UnityEngine;

public class EnemySetHandler : MonoBehaviour
{
    private Tween enemiesTween;
    private void Start()
    {
        EventsManager.Instance.OnGameStart += OnGameStart;
        EventsManager.Instance.OnGameOver += OnGameOver;
        EventsManager.Instance.OnRocketHit += OnRocketHit;

    }
    private void OnDestroy()
    {
        EventsManager.Instance.OnGameStart -= OnGameStart;
        EventsManager.Instance.OnGameOver -= OnGameOver;
        EventsManager.Instance.OnRocketHit -= OnRocketHit;
    }

    private void OnGameStart()
    {
        MoveEnemySet();
    }

    private void OnGameOver()
    {
        enemiesTween?.Kill();
    }

    private void OnRocketHit(Rocket i_Rocket, bool i_IsEnemyHit)
    {
        int activeEnemies = 0;
        foreach(Transform enemy in transform)
        {
            if(enemy.gameObject.activeInHierarchy)
            {
                activeEnemies++;
            }
        }

        activeEnemies -= 1;

        if(activeEnemies <= 0)
        {
            EventsManager.Instance.InvokeOnGameWon(0);
        }

        Debug.Log("Active Enemies: " + activeEnemies);
    }

    private void MoveEnemySet()
    {
        enemiesTween?.Kill();

        enemiesTween = transform.DOMoveX(30f, 12f, true)
        .SetEase(Ease.Linear)
        .SetLoops(-1, LoopType.Yoyo);
    }
}
