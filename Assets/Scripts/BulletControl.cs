using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    private Rigidbody2D rb2d;
    [SerializeField] public bool HasBeenShot;
    [SerializeField] public float BulletSpeed = 10;
    [SerializeField] public float revSpeed;
    private GameObject Player;
    private Animator Anim;
    public GameObject ImpactExplostion;

    


    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("BulletSpawmer");
        Anim = gameObject.GetComponent<Animator>();
;
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            GameObject bullet = Instantiate(ImpactExplostion, collision.gameObject.transform);
            bullet.transform.parent = null;
            Destroy(this.gameObject);
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
        }

    }

    
}
