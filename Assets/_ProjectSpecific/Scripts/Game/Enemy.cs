using System.Collections;
using UnityEditor.PackageManager;
using UnityEngine;

public class Enemy : Ship
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
        StartCoroutine(FireRandomly());
    }

    private IEnumerator FireRandomly()
    {
        yield return new WaitForSeconds(Random.Range(3f, 8f));
        EventsManager.Instance.InvokeOnEnemyFire(transform);

    }
    protected override void Fire()
    {
        EventsManager.Instance.InvokeOnEnemyFire(transform);
    }
}
