using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        EventsManager.Instance.InvokeOnGameStart();
    }

    private void OnDestroy()
    {
        
    }
}
