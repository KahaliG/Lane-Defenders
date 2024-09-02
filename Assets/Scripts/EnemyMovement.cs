using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] public float ScrollSpeed;
    [SerializeField] public const float ScrollWidth = 15;
    public bool CanReceiveGameInput;
    private bool StunWaitTime;
    private float StunnedSped;
    public float StunTime;
    public float Timer;
    public float Speed;
    public float Sped;
    public float transferSped;

    public void Start()
    {
        transferSped = Speed;
        StunTime = 0.5f;
        Timer = 0;
    }

    void FixedUpdate()
    {
        //if (CanReceiveGameInput == true)
        //{
        //    Vector3 pos = transform.position;


        //    pos.x -= ScrollSpeed * Time.deltaTime;

        //    if (transform.position.x < -ScrollWidth)
        //    {
        //        HandleOffScreen(ref pos);
        //    }
        //    transform.position = pos;
        //}
    }

    protected virtual private void HandleOffScreen(ref Vector3 pos)
    {
        pos.x += 10 * ScrollWidth;

    }

    public void Update()
    {
        if (StunWaitTime == true)
        {
            Timer += Time.deltaTime;
            if (Timer >= StunTime)
            {
                transferSped = ScrollSpeed;
                Timer = 0;
                StunWaitTime = false;
            }

        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "PlayerBullet")
        {
            transferSped = StunnedSped;
            StunWaitTime = true;
        }

    }
}
