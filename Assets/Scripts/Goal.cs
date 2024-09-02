using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    public TMP_Text LivesText;
    public PlayerController PlayerControllerInstance;
    public AudioClip LifeLost;
    [SerializeField] public GameObject GameOverMenu;
    public GameObject Player;
    public GameObject goal;

    public GameManager gameManager;


    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyMovement>() != null)
        {

            if (collision.gameObject.tag == "Enemy")
            {
                AudioSource.PlayClipAtPoint(LifeLost, transform.position);
                gameManager.Lives--;
                LivesText.text = "Lives: " + gameManager.Lives.ToString();
                
            }
        }


        if (gameManager.Lives <= 0)
        {
            LoseGame();
        }
    }

    public void LoseGame()
    {
        Time.timeScale = 0;
        GameOverMenu.SetActive(true);
        PlayerControllerInstance.CanReceiveGameInput = (false);
        gameManager.HighScoreUpdate();
    }
}
