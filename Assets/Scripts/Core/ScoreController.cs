using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public static ScoreController instance;
    [SerializeField]
    private Text _scoreUpperPanelText;
    [SerializeField]
    private Text _scoreGameOverPanelText;
    [SerializeField]
    private Text _bestScorePanel;

    private const string _bestScoreKey = "BestScore";
    private const string _currentScoreKey = "Score";

    //TODO: do class container
    private const string _gameOverText = "Your score : " + "\n";
    private const string _bestScoreText = "Best score : " + "\n";
    private const string _upperPanelText = "Score : " + "\n";

    private void OnEnable()
    {
        GameStateController.OnGameStart += SetStartScoreFields;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void SetStartScoreFields()
    {
        _scoreUpperPanelText.text = _upperPanelText + 0;
        _bestScorePanel.text = _bestScoreText + PlayerPrefs.GetInt(_bestScoreKey, 0);
        _scoreGameOverPanelText.text = _gameOverText + 0;
        PlayerPrefs.SetInt(_currentScoreKey, 0);
    }

    public void SetCurrentScore(int score)
    {
        var currentScore = PlayerPrefs.GetInt(_currentScoreKey, 0) + score;
        PlayerPrefs.SetInt(_currentScoreKey, currentScore);
        _scoreUpperPanelText.text = _upperPanelText + PlayerPrefs.GetInt(_currentScoreKey,0);
        _scoreGameOverPanelText.text = _gameOverText + PlayerPrefs.GetInt(_currentScoreKey, 0); ;

        if (currentScore > PlayerPrefs.GetInt(_bestScoreKey, 0))
        {
            SetNewBestScore(currentScore);
        }     
    }

    private void SetNewBestScore(int score)
    {
        PlayerPrefs.SetInt(_bestScoreKey, score);
        _bestScorePanel.text = _bestScoreText + PlayerPrefs.GetInt(_bestScoreKey, 0);
    }

    private void OnDisable()
    {
        GameStateController.OnGameStart -= SetStartScoreFields;
    }
}
