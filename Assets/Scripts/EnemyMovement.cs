using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] public float ScrollSpeed;
    [SerializeField] public const float ScrollWidth = 15;
    public bool CanReceiveGameInput;

    void FixedUpdate()
    {
        if (CanReceiveGameInput == true)
        {
            Vector3 pos = transform.position;


            pos.x -= ScrollSpeed * Time.deltaTime;

            if (transform.position.x < -ScrollWidth)
            {
                HandleOffScreen(ref pos);
            }
            transform.position = pos;
        }
    }

    protected virtual private void HandleOffScreen(ref Vector3 pos)
    {
        pos.x += 10 * ScrollWidth;

    }
}
