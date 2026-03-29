using DG.Tweening;
using UnityEngine;

public class EnemySetHandler : MonoBehaviour
{
    private void Start()
    {
        EventsManager.Instance.OnGameStart += OnGameStart;
    }

    private void OnDestroy()
    {
        EventsManager.Instance.OnGameStart -= OnGameStart;
    }

    private void OnGameStart()
    {
        MoveEnemySet();
    }

    private void MoveEnemySet()
    {
        transform.DOMoveX(16f, 12f, true)
        .SetEase(Ease.Linear)
        .SetLoops(-1, LoopType.Yoyo);
    }
}
