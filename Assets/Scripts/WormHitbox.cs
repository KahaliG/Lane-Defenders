using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormHitbox : MonoBehaviour
{
    public GameObject Enemy;
    private bool beenHit;
    [SerializeField] public int Lives;
    [SerializeField] public bool ScoreBox;
    public AudioClip EnemyDied;
    private bool stunnedwaittime;
    private float StunnedSped;
    public float StunTime;
    public float Timer = 33;
    public float Speed;
    public float Sped;
    public float transferSped;     
    public Animator Anim;

    public void Start()
    {
        Anim = gameObject.GetComponent<Animator>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (stunnedwaittime == true)
        {
            Timer += Time.deltaTime;
            if (Timer >= StunTime)
            {
                transferSped = Speed;
                Timer = 0;
                // EnemyAnimation.SetBool("Shot", false);
                stunnedwaittime = false;
            }
        }

        if (collision.gameObject.tag == "PlayerBullet")
        {
            Lives--;
            transferSped = StunnedSped;
            stunnedwaittime = true;
        }

        if (Lives < 0)
        {
            Anim.SetTrigger("Hit");
            AudioSource.PlayClipAtPoint(EnemyDied, transform.position);
            Destroy(gameObject);
            GameManager GM = FindObjectOfType<GameManager>();

            if (ScoreBox)
            {
                GM.UpdateScoreWorm();
            }
        }

        if (collision.gameObject.tag == "PlayerController")
        {
            Destroy(this.gameObject);
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

