using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUIHandler : MonoBehaviour
{
    [Header("Game Over Settings")]
    [SerializeField] private GameObject m_Container;
    [Space]
    [SerializeField] private TMP_Text m_DisplayText;
    [SerializeField] private Button m_ReturnToMenuButton;
    
    private void Start()
    {
        EventsManager.Instance.OnGameOver += OnGameOver;
        EventsManager.Instance.OnGameWon += OnGameWon;

        m_ReturnToMenuButton.onClick.AddListener(OnReturnToMenuButtonPressed);
    }

    private void OnDestroy()
    {
        EventsManager.Instance.OnGameOver -= OnGameOver;
        EventsManager.Instance.OnGameWon -= OnGameWon;

        m_ReturnToMenuButton.onClick.RemoveListener(OnReturnToMenuButtonPressed);
    }

    private void OnGameOver()
    {
        m_Container.SetActive(true);
    }

    private void OnGameWon(int i_FinalScore)
    {
        m_DisplayText.text = "You Won!\n\nFinal Score: " + i_FinalScore.ToString();
        m_Container.SetActive(true);
    }

    private void OnReturnToMenuButtonPressed()
    {
        SceneManager.LoadScene(0);
    }
}
