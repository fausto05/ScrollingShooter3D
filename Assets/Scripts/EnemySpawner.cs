using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 2f;
    private float timer;
    public Transform playerTransform;

    public float xRange = 10f;
    public float yRange = 5f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }

    void SpawnEnemy()
    {
        Vector3 spawnPos = transform.position + new Vector3(
            Random.Range(-xRange, xRange),
            Random.Range(-yRange, yRange),
            0f
        );

        GameObject Enemigo = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);

        EnemyController enemyScript = Enemigo.GetComponent<EnemyController>();
        if (enemyScript != null)
        {
            enemyScript.playerTransform = playerTransform;
        }
    }
}
