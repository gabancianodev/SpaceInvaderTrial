using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        EventsManager.Instance.InvokeOnAppStart();

        Application.targetFrameRate = 60;
    }

    private void OnDestroy()
    {
        
    }
}
