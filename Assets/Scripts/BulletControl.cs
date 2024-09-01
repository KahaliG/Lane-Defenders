using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    private Rigidbody2D rb2d;
    [SerializeField] public bool HasBeenShot;
    [SerializeField] public float BulletSpeed = 10;
    [SerializeField] public float revSpeed;
    [SerializeField] private GameObject Player;
    private Animator Anim;
    


    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("BulletSpawmer");
        Anim = gameObject.GetComponent<Animator>();
;
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Anim.SetTrigger("Explosion");
            BulletSpeed = rb2d.velocity.x * 55f;
            rb2d.velocity = Vector2.zero;
            Anim.SetTrigger("DestroyObj");
        }
    }


    public void Shoot()
    {
        if (HasBeenShot == false)
        {
            HasBeenShot = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(UnityEngine.Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f));
            Debug.Log(rb2d.velocity.magnitude);
            rb2d.MoveRotation(rb2d.rotation + revSpeed * Time.fixedDeltaTime);
            StartCoroutine(Lock());
        }

    }

    public IEnumerator Lock()
    {
        yield return new WaitForSeconds(15f);
    }
}
