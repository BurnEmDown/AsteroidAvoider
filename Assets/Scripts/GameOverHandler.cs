using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverHandler : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Button continueButton;
    [SerializeField] private TMP_Text gameOverText;
    [SerializeField] private ScoreSystem scoreSystem;
    [SerializeField] private GameObject gameOverDisplay;
    [SerializeField] private AsteroidSpawner asteroidSpawner;
    
    public void EndGame()
    {
        asteroidSpawner.enabled = false;
        gameOverDisplay.gameObject.SetActive(true);
        continueButton.interactable = true;
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
        AdManager.Instance.ShowAd(this);

        continueButton.interactable = false;
    }

    public void ContinueGame()
    {
        scoreSystem.StartTimer();

        asteroidSpawner.enabled = true;
        
        gameOverDisplay.gameObject.SetActive(false);
        
        player.transform.position = Vector3.zero;
        player.SetActive(true);
        player.GetComponent<PlayerMovement>().ResetVelocity();
    }
}
