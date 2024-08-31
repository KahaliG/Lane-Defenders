using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerDelay : MonoBehaviour
{
    [SerializeField] public GameObject EnemyPrefab;
    private Transform SpawnPosition;
    public float spawnTimer = 3f;
    private Coroutine CurrentTimer;
    public float timer = 1f;


    private void Start()
    {
        if (CurrentTimer == null)
        {
            CurrentTimer = StartCoroutine(SpawnTimer());
        }

    }

    public IEnumerator SpawnTimer()
    {
        //Spawn bullet
        SpawnEnemyInstance();

        //While the button is being held down or when the timer reaches 3 seconds
        while (timer > 0)
        {
            //Timer of the cooldown for the bullet to reach 0
            timer -= Time.deltaTime;

            //If timer has succesfully reached 0 then player is able to shoot bullet again
            if (timer <= 0  == true)
            {
                //Shoots the bullet again
                SpawnEnemyInstance();
            }
            yield return null;
            //Repeat the corotine 
        }
        timer = 1f;
        //Timer has reset back to 3 seconds

        CurrentTimer = null;
        //timer for the Coroutine resets allowing player to shoot again when timer reaches 0
    }

    public void SpawnEnemyInstance()
    {
        Instantiate(EnemyPrefab, SpawnPosition.position, Quaternion.identity);
    }
}
