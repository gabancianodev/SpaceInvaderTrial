using System.Collections;
using UnityEditor.PackageManager;
using UnityEngine;

public class Enemy : Ship
{
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
        StartCoroutine(FireRandomly());
    }

    private void OnGameOver()
    {
        StopAllCoroutines();
    }

    private IEnumerator FireRandomly()
    {
        yield return new WaitForSeconds(Random.Range(4f, 8f));

        while (true)
        {
            Fire();
            float nextFireDelay = Random.Range(5f, 8f);
            yield return new WaitForSeconds(nextFireDelay);
        }
    }
    protected override void Fire()
    {
        EventsManager.Instance.InvokeOnEnemyFire(transform);
    }
}
