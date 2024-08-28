using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormHitbox : MonoBehaviour
{
    [SerializeField] public bool ScoreBox;
    private bool beenHit;
    [SerializeField] public int Lives;
    [SerializeField] public GameObject bullet;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<BulletControl>() != null)
        {
            GameManager GM = FindObjectOfType<GameManager>();
            

            if (ScoreBox)
            {
                GM.UpdateScoreWorm();
            }
        }

        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            GameManager GM = FindObjectOfType<GameManager>();


            if (ScoreBox)
            {
                GM.UpdateScoreWorm();
            }
        }

        if (collision.gameObject.tag == "PlayerBullet")
        {
            Lives--;
        }


        if (Lives < 0)
        {
            Destroy(gameObject);
        }



        if (beenHit)
        {
            

        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerController")
        {
            Destroy(this.gameObject);
        }
    }
}

