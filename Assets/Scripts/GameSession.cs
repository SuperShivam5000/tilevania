using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives=3;
    [SerializeField]int score=0;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI scoreText;
    void Awake()
    {
        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if(numGameSessions > 1)
        {
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
        }
    }
    public void ProcessPlayerDeath(){
        if(playerLives > 1) {
            TakeLife();
        } else {
            ResetGameSession();
        }
    }
    void TakeLife(){
        playerLives--;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        livesText.text = playerLives.ToString();
    }
    void ResetGameSession(){
        FindObjectOfType<ScenePersist>().ResetScenePersist();
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
    public void AddToScore(int pointsToAdd){
        score+=pointsToAdd;
        scoreText.text = score.ToString();
    }
    void Start() {
        livesText.text = playerLives.ToString();
        scoreText.text = score.ToString();
    }
}
