using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUIHandler : MonoBehaviour
{
    [Header("Game Over Settings")]
    [SerializeField] private GameObject m_Container;
    [Space]
    [SerializeField] private Button m_ReturnToMenuButton;
    
    private void Start()
    {
        EventsManager.Instance.OnGameOver += OnGameOver;

        m_ReturnToMenuButton.onClick.AddListener(OnReturnToMenuButtonPressed);
    }

    private void OnDestroy()
    {
        EventsManager.Instance.OnGameOver -= OnGameOver;

        m_ReturnToMenuButton.onClick.RemoveListener(OnReturnToMenuButtonPressed);
    }

    private void OnGameOver()
    {
        m_Container.SetActive(true);
    }

    private void OnReturnToMenuButtonPressed()
    {
        SceneManager.LoadScene(0);
    }
}
