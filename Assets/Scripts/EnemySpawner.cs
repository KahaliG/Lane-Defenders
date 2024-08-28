using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
   [SerializeField] public GameObject SlimePrefab;
   [SerializeField] public float Timer;
   [SerializeField] public bool RunGame;
   [SerializeField] public Transform SpawnPosition;

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    public IEnumerator SpawnEnemy()
    {
        float currentTime = Timer;
        {
            currentTime += Time.deltaTime;
            if (currentTime <= 0)
            {
                SpawnEnemyInstance();
                currentTime = Timer;
            }

            yield return null;
        } 
    }

    public void SpawnEnemyInstance()
    {
        Instantiate(SlimePrefab, SpawnPosition.position, Quaternion.identity);
    }
}
