using System.Collections;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public PlayerController PlayerControllerInstance;
    public GameObject slimePrefab;
    public GameObject wormPrefab;
    public GameObject SnailPrefab;
    public TMP_Text scoreText;
    public TMP_Text finalScoreText;
    public TMP_Text highScoreText;
    public int currentScore;
    public float SlimeTimer = 2;
    public float SnailTimer = 3;
    public float WormTimer = 3;
    public bool RunGame;
    public Transform SpawnPosition1;
    public Transform SpawnPosition2;
    public Transform SpawnPosition3;
    public Transform SpawnPosition4;
    public Transform SpawnPosition5;
    public Transform SpawnPosition6;
    public Transform SpawnPosition7;
    public float backgroundMovementModifier;

    private void Start()
    {
        StartCoroutine(SpawnSlime());
    }

    public IEnumerator SpawnSlime()
    {
        float currentSlimeTime = SlimeTimer;
        float currentSnailTime = SnailTimer;
        float currentWormTime = WormTimer;

        while (RunGame)
        {
            currentSlimeTime -= Time.deltaTime;
            if (currentSlimeTime <= 0)
            {
                SpawnSlimeInstance();
                currentSlimeTime = SlimeTimer;
            }

            yield return null;

            currentSnailTime -= Time.deltaTime;
            if (currentSnailTime <= 0)
            {
                SpawnWormInstance();
                currentSnailTime = SnailTimer;
            }

            yield return null;

            currentWormTime -= Time.deltaTime;
            if (currentWormTime <= 0)
            {
                SpawnSnailInstance();
                currentWormTime = WormTimer;
            }

            yield return null;
        }
    }

    public void SpawnSlimeInstance()
    {
        Instantiate(slimePrefab, SpawnPosition1.position, Quaternion.identity);
        Instantiate(slimePrefab, SpawnPosition3.position, Quaternion.identity);
        Instantiate(slimePrefab, SpawnPosition5.position, Quaternion.identity);
    }

    public void SpawnSnailInstance()
    {
        Instantiate(SnailPrefab, SpawnPosition6.position, Quaternion.identity);
        Instantiate(SnailPrefab, SpawnPosition7.position, Quaternion.identity);
    }

    public void SpawnWormInstance()
    {
        Instantiate(wormPrefab, SpawnPosition2.position, Quaternion.identity);
        Instantiate(wormPrefab, SpawnPosition4.position, Quaternion.identity);
    }

    public void UpdateScoreSlime()
    {
        currentScore += 100;
        scoreText.text = "Score: " + currentScore.ToString();
    } 
    
    public void UpdateScoreWorm()
    {
        currentScore += 400;
        scoreText.text = "Score: " + currentScore.ToString();
    }
    
    public void UpdateScoreSnail()
    {
        currentScore += 700;
        scoreText.text = "Score: " + currentScore.ToString();
    }

    public void HighScoreUpdate()
    {
        if (PlayerPrefs.HasKey("SavedHighScore"))
        {
            if(currentScore > PlayerPrefs.GetInt("SavedHighScore"))
            {
                PlayerPrefs.SetInt("SavedHighScore", currentScore);
            }
        }
        else
        {
            PlayerPrefs.SetInt("SavedHighScore", currentScore);
        }
        finalScoreText.text = "Score: " + currentScore.ToString();
        highScoreText.text = "HighScore: " + PlayerPrefs.GetInt("SavedHighScore").ToString();
    }
}
