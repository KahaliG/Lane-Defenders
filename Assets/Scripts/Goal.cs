using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    public TMP_Text LivesText;
    [SerializeField] public int Lives;
    public PlayerController PlayerControllerInstance;
    public AudioClip LifeLost;
    [SerializeField] public GameObject GameOverMenu;
    public GameObject Player;
    public GameObject goal;

    public GameManager gameManger;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyMovement>() != null)
        {

            if (collision.gameObject.tag == "Enemy")
            {
                AudioSource.PlayClipAtPoint(LifeLost, transform.position);
                LivesText.text = "Lives: " + Lives.ToString();
                Lives--;
            }
        }


        if (Lives < 0)
        {
            LoseGame();
        }
    }

    public void LoseGame()
    {
        Time.timeScale = 0;
        GameOverMenu.SetActive(true);
        PlayerControllerInstance.CanReceiveGameInput = (false);
        gameManger.HighScoreUpdate();
    }
}
