using DG.Tweening;
using UnityEngine;

public class EnemySetHandler : MonoBehaviour
{
    private Tween enemiesTween;
    private void Start()
    {
        EventsManager.Instance.OnGameStart += OnGameStart;
        EventsManager.Instance.OnGameOver += OnGameOver;

    }
    private void OnDestroy()
    {
        EventsManager.Instance.OnGameStart -= OnGameStart;
        EventsManager.Instance.OnGameOver -= OnGameOver;
    }

    private void OnGameStart()
    {
        MoveEnemySet();
    }

    private void OnGameOver()
    {
        enemiesTween?.Kill();
    }

    private void MoveEnemySet()
    {
        enemiesTween?.Kill();

        enemiesTween = transform.DOMoveX(16f, 12f, true)
        .SetEase(Ease.Linear)
        .SetLoops(-1, LoopType.Yoyo);
    }
}
