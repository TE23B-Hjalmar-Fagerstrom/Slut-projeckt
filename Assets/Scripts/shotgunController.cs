using UnityEngine;

public class shotgunController : MonoBehaviour
{
    [SerializeField]
    GameObject bulletPrefab;

    [SerializeField]
    float timeBetweenShots = 1;
    float timeSinceShot = 0;
    float spread;

    Transform spawnPoint;

    int pelletCount = 120;

    void Start()
    {
        spawnPoint = transform.GetChild(0).transform;
    }

    public void Fire()
    {
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        Quaternion direction = Quaternion.Euler(x, y, 0);

        if (timeSinceShot > timeBetweenShots)
        {
            for (int i = 0; i < pelletCount; i++)
            {
            
                GameObject b = Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation * direction);
            }
            timeSinceShot = 0;
        }
    }

    void Update()
    {
        timeSinceShot += Time.deltaTime;
    }
}