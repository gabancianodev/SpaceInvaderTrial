using UnityEngine;
using UnityEngine.UI;

public class MainMenuUIHandler : MonoBehaviour
{
    [Header("Main Menu Settings")]
    [SerializeField] private GameObject m_Container;
    [Space]
    [SerializeField] private Button m_PlayButton;

    private void Start()
    {
        EventsManager.Instance.OnAppStart += OnAppStart;
        EventsManager.Instance.OnGameStart += OnGameStart;

        m_PlayButton.onClick.AddListener(OnPlayButtonPressed);
    }

    private void OnDestroy()
    {
        EventsManager.Instance.OnAppStart -= OnAppStart;
        EventsManager.Instance.OnGameStart -= OnGameStart;

        m_PlayButton.onClick.RemoveListener(OnPlayButtonPressed);
    }

    private void OnAppStart()
    {
        m_Container.SetActive(true);
    }

    private void OnGameStart()
    {
        m_Container.SetActive(false);
    }

    private void OnPlayButtonPressed()
    {
        AudioManager.Instance.PlaySFX(eAudioClips.UIPress);
        EventsManager.Instance.InvokeOnGameStart();
    }
}
