using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // 引入 TextMeshPro 命名空间
using UnityEngine.SceneManagement;

public class SheepGame : MonoBehaviour
{
    public GameObject sheepPrefab; 
    public GameObject playerPrefab; 
    public int sheepCount = 10; 
    public float spawnRangeX = 10f; 
    public float spawnRangeZ = 10f; 
    public float gameDuration = 30f; 
    public TMP_Text timerText; 
    public TMP_Text scoreText; 
    public TMP_Text restartText; 

    public AudioClip sheepSound; 
    private AudioSource audioSource; 

    private float timer;
    private int score;
    private bool gameIsOver; 
    private bool canScore; 

    void Start()
    {
        timer = gameDuration;
        score = 0;
        gameIsOver = false; 
        canScore = true; 
        UpdateScoreText();
        SpawnSheep();
        restartText.gameObject.SetActive(false); 

        
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    void Update()
    {
        if (!gameIsOver)
        {
            
            timer -= Time.deltaTime;
            UpdateTimerText();

            
            if (timer <= 0)
            {
                EndGame();
            }
        }
        else
        {
            
            if (Input.GetKeyDown(KeyCode.R))
            {
                RestartGame();
            }
        }
    }

    
    void SpawnSheep()
    {
        for (int i = 0; i < sheepCount; i++)
        {
            Vector3 spawnPosition = new Vector3(
                Random.Range(-spawnRangeX, spawnRangeX),
                0.5f, 
                Random.Range(-spawnRangeZ, spawnRangeZ)
            );
            Instantiate(sheepPrefab, spawnPosition, Quaternion.identity);
        }
    }

   
    void UpdateTimerText()
    {
        timerText.text = "Time: " + Mathf.Max(0, Mathf.Ceil(timer)).ToString();
    }

    
    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

  
    void EndGame()
    {
        Time.timeScale = 0; 
        gameIsOver = true; 
        canScore = false; 
        restartText.gameObject.SetActive(true); 
        Debug.Log("Game Over! Press R to Restart");
    }

    
    private void OnTriggerEnter(Collider other)
    {
       
        if (canScore && other.gameObject.CompareTag("Sheep"))
        {
            score += 15; 
            UpdateScoreText();
            PlaySheepSound(); 
            Destroy(other.gameObject); 
        }
    }

    
    void PlaySheepSound()
    {
        if (sheepSound != null)
        {
            audioSource.PlayOneShot(sheepSound);
        }
    }

   
    public void RestartGame()
    {
        Time.timeScale = 1; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }
}