using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerInput MyPlayerInput;
    [SerializeField] public float TankSpeed; 
    [SerializeField] public Rigidbody2D Tank; 
    [SerializeField] public GameObject rocket;
    [SerializeField] public GameObject BulletSpawner;
    [SerializeField] public Transform bulletSpawner;
    [SerializeField] public float bulletSpeed;
    [SerializeField] public GameManager gameManager;
    [SerializeField] public bool CanReceiveGameInput;
    private InputAction Move;
    private InputAction Shoot;
    private InputAction Restart;
    private InputAction Quit;
    private bool tankShouldBeMoving;
    public bool HasBeenClicked;
    public float timer = 2f;
    private float moveDirection;
    private Coroutine CurrentTimer;
    private Animator Anim;
    public AudioClip BulletShot;
   

    void Start()
    {
        MyPlayerInput = GetComponent<PlayerInput>();
        Move = MyPlayerInput.currentActionMap.FindAction("Move");
        Shoot = MyPlayerInput.currentActionMap.FindAction("Shoot");
        Restart = MyPlayerInput.currentActionMap.FindAction("RestartGame");
        Quit = MyPlayerInput.currentActionMap.FindAction("QuitGame");
        Anim = gameObject.GetComponent<Animator>();

        Move.started += Handle_MovetStarted;
        Shoot.started += Handle_ShootStarted;
        Restart.performed += Handle_RestartPreformed;
        Quit.performed += Handle_QuitPreformed;
        Move.canceled += Handle_MoveCancled;
        Shoot.canceled += Handle_ShootCanceled;
    }

    private void OnDestroy()
    {
        Move.started -= Handle_MovetStarted;
        Shoot.started -= Handle_ShootStarted;
        Restart.performed -= Handle_RestartPreformed;
        Quit.performed -= Handle_QuitPreformed;
        Move.canceled -= Handle_MoveCancled;
        Shoot.canceled -= Handle_ShootCanceled;
    }

    private void Handle_ShootCanceled(InputAction.CallbackContext obj)
    {
        HasBeenClicked = false;
    }

    private void Handle_MovetStarted(InputAction.CallbackContext obj)
    {
        if (CanReceiveGameInput == true)
        {
            tankShouldBeMoving = true; 
        }
    }

    private void Handle_MoveCancled(InputAction.CallbackContext obj)
    {
        if (CanReceiveGameInput == true)
        {
            tankShouldBeMoving = false;
        }
    }

    private void Handle_QuitPreformed(InputAction.CallbackContext obj)
    {
        Application.Quit();
    }

    private void Handle_RestartPreformed(InputAction.CallbackContext obj)
    {
        SceneManager.LoadScene(0);
    }

    private void Handle_ShootStarted(InputAction.CallbackContext obj)
    {
       //Starts the corotine

        HasBeenClicked = true;
       if (CurrentTimer == null)
        {
            CurrentTimer = StartCoroutine(BulletTimer());
        }


    }

    public void SpawnBullet()
    {
        //Bullet it self

        //Anim.SetActive(true);
        //Anim.SetTrigger("Hit");
        GameObject bullet = Instantiate(rocket, bulletSpawner.position, Quaternion.identity);
        Rigidbody2D bulletrb2d = bullet.GetComponent<Rigidbody2D>();
        var rads = (transform.eulerAngles.z) * Mathf.Deg2Rad;
        Vector2 vec = bulletSpeed * new Vector2(Mathf.Cos(rads), Mathf.Sin(rads));
        bulletrb2d.velocity = vec;
        AudioSource.PlayClipAtPoint(BulletShot, transform.position);
      //  Anim.SetActive(false);

        timer = 1.3f;
        //Timer of the bullet 
    }

    public IEnumerator BulletTimer()
    {
        //Spawn bullet
        SpawnBullet();

        //While the button is being held down or when the timer reaches 3 seconds
       while (HasBeenClicked == true || timer > 0)
        {
            //Timer of the cooldown for the bullet to reach 0
            timer -= Time.deltaTime;

            //If timer has succesfully reached 0 then player is able to shoot bullet again
            if (timer <= 0 && HasBeenClicked == true)
            {
                //Shoots the bullet again
                SpawnBullet();
            }
            yield return null;
           //Repeat the corotine 
        }
        timer = 1.3f;
        //Timer has reset back to 3 seconds

        CurrentTimer = null;
        //timer for the Coroutine resets allowing player to shoot again when timer reaches 0
    }

    public void FixedUpdate()
    {
        if (tankShouldBeMoving)
        {
            Tank.velocity = new Vector2(0, TankSpeed * moveDirection);
        }
        else 
        {
            Tank.velocity = new Vector2(0, 0);
        }

    }

    public void Update()
    {
        if(tankShouldBeMoving)
        {
            moveDirection = Move.ReadValue<float>();
        }
    }
}
