using TMPro;
using UnityEngine;

public class GameUIHandler : MonoBehaviour
{
    [SerializeField] private GameObject m_Container;
    [Space]
    [SerializeField] private TMP_Text m_ScoreText;
    [SerializeField] private TMP_Text m_LivesText;
    private void Start()
    {
        EventsManager.Instance.OnGameStart += OnGameStart;
        EventsManager.Instance.OnGameOver += OnGameOver;
        EventsManager.Instance.OnScoreUpdate += OnScoreUpdate;
        EventsManager.Instance.OnLivesUpdate += OnLivesUpdate;
    }

    private void OnDestroy()
    {
        EventsManager.Instance.OnGameStart -= OnGameStart;
        EventsManager.Instance.OnGameOver -= OnGameOver;
        EventsManager.Instance.OnScoreUpdate -= OnScoreUpdate;
        EventsManager.Instance.OnLivesUpdate -= OnLivesUpdate;
    }

    private void OnGameStart()
    {
        m_Container.SetActive(true);
    }

    private void OnGameOver()
    {
        m_Container.SetActive(false);
    }

    private void OnScoreUpdate(int i_NewScore)
    {
        m_ScoreText.text = "Score: " + "<color=green>" + i_NewScore.ToString() + "</color>";
    }

    private void OnLivesUpdate(int i_NewLives)
    {
        m_LivesText.text = "Lives: " + "<color=red>" + i_NewLives.ToString() + "</color>";
    }
}
