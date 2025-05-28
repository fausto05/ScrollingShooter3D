using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 2f;
    public Transform playerTransform;
    
    private float fireTimer;

    public void Update()
    {
        if (playerTransform != null)
        {
            transform.LookAt(playerTransform);
        }
        transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
        
        // Disparo automatico
        fireTimer += Time.deltaTime;
        if (fireTimer >= fireRate)
        {
            Shoot();
            fireTimer = 0f;
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            GameManager.Instance.AddKill();
        }
    }
}
