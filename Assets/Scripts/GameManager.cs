using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public int lives;
    public int score;
    public Text livesText;
    public Text scoreText;
    public bool gameOver;
    public GameObject gameOverPanel;
    public GameObject loadLevelPanel;
    public int numberOfBricks;
    public Transform[] levels;
    public int currentLevelIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        livesText.text = "Lives: " + lives;
        scoreText.text = "Score: " + score;
        numberOfBricks = GameObject.FindGameObjectsWithTag("Brick").Length;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateLives(int changeInLives) {
        lives += changeInLives;
        
        if( lives <= 0){
            lives = 0;
            GameOver ();
        }
        livesText.text = "Lives: " + lives;
    }

    public void UpdateScore(int points){
        score += points;

        scoreText.text = "Score: " + score;
    }

    public void UpdateNumberOfBricks(){
        numberOfBricks--;
        if (numberOfBricks <= 0){
            if(currentLevelIndex >= levels.Length - 1){
                GameOver();
            } else {
                loadLevelPanel.SetActive(true);
                gameOver = true;
                Invoke("LoadLevel", 3f);
            }
        }
    }

    void LoadLevel(){
        currentLevelIndex++;
        Instantiate(levels[currentLevelIndex], Vector3.zero, Quaternion.identity);
        numberOfBricks = GameObject.FindGameObjectsWithTag("Brick").Length;
        gameOver = false;
        loadLevelPanel.SetActive(false);
    }

    void GameOver(){
        gameOver = true;
        gameOverPanel.SetActive(true);
    }

    public void PlayAgain(){
        SceneManager.LoadScene("SampleScene");
    }

    public void Quit(){
        SceneManager.LoadScene("StartMenu");
    }

}
