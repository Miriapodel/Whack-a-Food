using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public List<GameObject> targets;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;

    public Button button;

    private int score = 0;

    private float startDelay = 1;

    public bool isGameActive = true;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    IEnumerator SpawnTarget()
    {
        while(isGameActive)
        {
            yield return new WaitForSeconds(startDelay);

            int randomIndex = Random.Range(0, targets.Count);

            Instantiate(targets[randomIndex]);  

        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;

        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        button.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
        startDelay /= difficulty;

        StartCoroutine(SpawnTarget());

        scoreText.text = "Score: " + score;
    }

}
