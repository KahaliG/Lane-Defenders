using System.Collections;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public PlayerController PlayerControllerInstance;
    public GameObject SlimePrefab;
    public GameObject WormPrefab;
    public GameObject SnailPrefab;
    public TMP_Text Score;
    public int MainScore;
    public float Timer;
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
        float currentTime = Timer;
        while (RunGame)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0)
            {
                SpawnSlimeInstance();
                currentTime = Timer;
            }

            yield return null;
        }
    }

    public void SpawnSlimeInstance()
    {
        Instantiate(SlimePrefab, SpawnPosition1.position, Quaternion.identity);
        Instantiate(WormPrefab, SpawnPosition2.position, Quaternion.identity);
        Instantiate(SlimePrefab, SpawnPosition3.position, Quaternion.identity);
        Instantiate(WormPrefab, SpawnPosition4.position, Quaternion.identity);
        Instantiate(SlimePrefab, SpawnPosition5.position, Quaternion.identity);
        Instantiate(SnailPrefab, SpawnPosition6.position, Quaternion.identity);
        Instantiate(SnailPrefab, SpawnPosition7.position, Quaternion.identity);
    }

    public void UpdateScoreSlime()
    {
        MainScore += 100;
        Score.text = "Score: " + MainScore.ToString();
    } 
    
    public void UpdateScoreWorm()
    {
        MainScore += 500;
        Score.text = "Score: " + MainScore.ToString();
    }
    
    public void UpdateScoreSnail()
    {
        MainScore += 800;
        Score.text = "Score: " + MainScore.ToString();
    }

    public void LoseGame()
    {
        PlayerControllerInstance.CanReceiveGameInput = (false);
    }
}
