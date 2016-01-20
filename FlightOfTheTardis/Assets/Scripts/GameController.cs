using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    public GameObject [] hazards;
    //public GameObject[] collectables;
    //public int pickUpCount; 
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnEnemyWait;
    //public float spawnPickUpWait;
    public float startWait;
    public float waveWait;
    public Text scoreText;
    public Text gameOverText;
    public CanvasGroup retry;
    public int score;
    bool gameOver;
   
   

    void Start()
    {
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
        retry.alpha = 0f;
        //StartCoroutine(SpawnCollectionaves());
    }
    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }
    public void AddNewScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }
   
    public void GameOver()
    {
        //Display Game Over Message
        gameOverText.text = "Game Over!";
        retry.alpha = 1.0f;
        gameOver = true;
    }
    
    public void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
    
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), Random.Range(-spawnValues.y, spawnValues.y), spawnValues.z);
                
                Quaternion spawnRotation = Quaternion.identity;
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnEnemyWait);
            }
            yield return new WaitForSeconds(waveWait);
            if (gameOver)
            {
                break;
            }
        }
    }
   /* IEnumerator SpawnCollectionWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < pickUpCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), Random.Range(-spawnValues.y, spawnValues.y), spawnValues.z);

                Quaternion spawnRotation = Quaternion.identity;
                GameObject collectable = collectables[Random.Range(0, collectables.Length)];
                Instantiate(collectable, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnPickUpWait);
            }
            yield return new WaitForSeconds(waveWait);
            if (gameOver)
            {
                break;
            }
        }
    }*/
}
