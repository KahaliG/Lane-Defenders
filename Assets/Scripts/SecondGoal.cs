using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecondGoal : MonoBehaviour
{
    public TMP_Text LivesText;
    [SerializeField] public int Lives;
    [SerializeField] public bool ScoreBox;
    public PlayerController PlayerControllerInstance;
    public AudioClip LifeLost;
    [SerializeField] public GameObject GameOverMenu;

    public void OnTriggerEnter2D(Collider2D collision)
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
        PlayerControllerInstance.CanReceiveGameInput = (false);       
        GameOverMenu.SetActive(true);
    }
}
