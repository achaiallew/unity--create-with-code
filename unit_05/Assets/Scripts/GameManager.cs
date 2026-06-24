using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;

    private float spawnRate = 1.0f;

    private int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;

    public bool gameActive = true;

    public Button restart;

    public GameObject title;
    

    void Start()
    {  

    }

     IEnumerator SpawnTarget()
    {
        while (gameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int i = Random.Range(0, targets.Count);
            Instantiate(targets[i]);
        }
    }

    public void UpdateScore(int addScore)
    {
        score += addScore;
        scoreText.text = "Score: " + score;

        if (score < 0){ GameOver();}
    }

    public void StartGame(int difficulty)
    {
        gameActive = true;
        score = 0;
        spawnRate /= difficulty;
        StartCoroutine(SpawnTarget());  
        UpdateScore(0);
        title.gameObject.SetActive(false);
    }

    public void GameOver()
    {
        gameActive = false;
        gameOverText.gameObject.SetActive(true);
        restart.gameObject.SetActive(true);
    
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
