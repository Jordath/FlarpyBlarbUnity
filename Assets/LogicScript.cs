using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    //public PlayerPrefs highScorePlayerPref;
    public int highScore;
    public Text scoreText;
    public TextMeshProUGUI highScoreText;
    public GameObject gameOverScreen;
    public AudioSource dingSFX;
    public GameObject startGameScreen;
    public AudioSource animyDeathSFX;
    public AudioClip animyDeathSFXClip;
    public AudioClip missleFiredSFX;
    public explosionScript explosionScript;
    public GameObject pauseScreen;

    public void Start()
    {
        highScoreText.SetText(PlayerPrefs.GetInt("High Score").ToString());
        Time.timeScale = 1;
        
    }


    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        if (!gameOverScreen.activeInHierarchy)
        {
            playerScore += scoreToAdd;
            scoreText.text = playerScore.ToString();
            dingSFX.Play();
        }
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        highScoreText.SetText(PlayerPrefs.GetInt("High Score").ToString());
    }

    public void quitGame()
    {
        loadSceneByName("StartGameScene");
    }
    public void loadSceneByName(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void changeScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

    public void gameOver() 
    {         
        gameOverScreen.SetActive(true);
        if(playerScore > PlayerPrefs.GetInt("High Score"))
        {
            saveHighScore();
            highScoreText.SetText(PlayerPrefs.GetInt("High Score").ToString());
        }
        
    }
    public void saveHighScore()
    {
        PlayerPrefs.SetInt("High Score", playerScore);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseScreen.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
    }

    public void AnimyDeath()
    {
        animyDeathSFX.PlayOneShot(animyDeathSFXClip);
        //animyDeathSFX.Play();
    }

    public void MissleFiredAudioCue()
    {
        animyDeathSFX.PlayOneShot(missleFiredSFX);

    }

    public void MissleExploding()
    {
        Instantiate(explosionScript, transform.position, transform.rotation);
        Destroy(explosionScript, 100);
    }
}
