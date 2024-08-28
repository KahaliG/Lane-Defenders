using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerInput MyPlayerInput;
    [SerializeField] public float TankSpeed; 
    [SerializeField] public Rigidbody2D Tank; 
    [SerializeField] public GameObject rocket;
    [SerializeField] public float bulletSpeed;
    [SerializeField] public GameManager gameManager;
    [SerializeField] public bool CanReceiveGameInput;
    private InputAction Move;
    private InputAction Shoot;
    private InputAction Restart;
    private InputAction Quit;
    private bool tankShouldBeMoving;
    private float moveDirection;



    void Start()
    {
        MyPlayerInput = GetComponent<PlayerInput>();
        Move = MyPlayerInput.currentActionMap.FindAction("Move");
        Shoot = MyPlayerInput.currentActionMap.FindAction("Shoot");
        Restart = MyPlayerInput.currentActionMap.FindAction("RestartGame");
        Quit = MyPlayerInput.currentActionMap.FindAction("QuitGame");
        //gameManager = FindObjectOfType<GameManager>();

        Move.started += Handle_MovetStarted;
        Shoot.started += Handle_ShootStarted;
        Restart.performed += Handle_RestartPreformed;
        Quit.performed += Handle_QuitPreformed;
        Move.canceled += Handle_MoveCancled;
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
        throw new NotImplementedException();
    }

    private void Handle_RestartPreformed(InputAction.CallbackContext obj)
    {
        throw new NotImplementedException();
    }

    private void Handle_ShootStarted(InputAction.CallbackContext obj)
    {
        Quaternion temp = transform.localRotation;
        GameObject bullet = Instantiate(rocket, transform.position, Quaternion.identity);
        Rigidbody2D bulletrb2d = bullet.GetComponent<Rigidbody2D>();
        var rads = (transform.eulerAngles.z) * Mathf.Deg2Rad;
        Vector2 vec = bulletSpeed * new Vector2(Mathf.Cos(rads), Mathf.Sin(rads));
        bulletrb2d.velocity = vec;

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
