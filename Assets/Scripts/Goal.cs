using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    public PlayerController PlayerControllerInstance;
    protected int Lives = 3;
    public GameManager GM;
    public TMP_Text LivesText;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            LivesText.text = "Lives: " + Lives.ToString();
            Lives--;
        }

        if (collision.gameObject.tag == "Enemy")
        {
            LivesText.text = "Lives: " + Lives.ToString();
            Lives--;          
        }

        if (collision.gameObject.tag == "Enemy")
        {
            LivesText.text = "Lives: " + Lives.ToString();
            Lives--;
        }

        if (Lives <= 0)
        {
            LoseGame();
        }
    }

    public void LoseGame()
    {
        PlayerControllerInstance.CanReceiveGameInput = (false);
        SceneManager.LoadScene(2);
    }
}
