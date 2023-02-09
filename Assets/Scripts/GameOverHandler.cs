using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverHandler : MonoBehaviour
{
    [SerializeField] private TMP_Text gameOverText;
    [SerializeField] private ScoreSystem scoreSystem;
    [SerializeField] private GameObject gameOverDisplay;
    [SerializeField] private AsteroidSpawner asteroidSpawner;
    
    public void EndGame()
    {
        asteroidSpawner.enabled = false;
        gameOverDisplay.gameObject.SetActive(true);
        int score = scoreSystem.GetScoreOnGameEnd();
        gameOverText.text = "Your score is " + score;
    }
    
    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
    }

    public void Continue()
    {
        
    }
}
