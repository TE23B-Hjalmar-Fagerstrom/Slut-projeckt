using UnityEngine;
using TMPro;

public class shotgunController : MonoBehaviour
{
    [SerializeField]
    GameObject bulletPrefab;

    [SerializeField]
    float timeBetweenShots = 1;
    float timeSinceShot = 0;
    float timeBetweenHasFired = 1;
    float timeSinceHasFired = 0;
    float spread = 5;

    [SerializeField]
    public int curentAmmo;
    int maxAmmo = 6;

    [SerializeField]
    TMP_Text ammoText;

    Transform spawnPoint;

    int pelletCount = 12;

    float timeBetweenReloads = 0.75f;
    float timeSinceLastReload = 0;

    public bool isReloading = false;
    public bool fireGun = false;
    public bool hasFired = false;

    void Start()
    {
        spawnPoint = transform.GetChild(0).transform;
        curentAmmo = maxAmmo;
    }

    public void Fire()
    {
        if (timeSinceShot > timeBetweenShots && curentAmmo > 0)
        {
            fireGun = true;
            for (int i = 0; i < pelletCount; i++)
            {
                float x = Random.Range(-spread, spread);
                float y = Random.Range(-spread, spread);

                Quaternion direction = Quaternion.Euler(x, y, 0);

                Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation * direction);
            }

            curentAmmo--;

            isReloading = false;
            fireGun = false;
            hasFired = true;

            timeSinceShot = 0;
            timeSinceHasFired = 0;
        }
        else if (curentAmmo == 0)
        {
            isReloading = true;
        }

    }

    public void Reload()
    {
        if (curentAmmo < maxAmmo)
        {
            isReloading = true;
        }
    }

    void Update()
    {
        timeSinceShot += Time.deltaTime;
        timeSinceHasFired += Time.deltaTime;

        ammoText.text = $"{curentAmmo} / 6";

        if (isReloading && curentAmmo < maxAmmo)
        {
            timeSinceLastReload += Time.deltaTime;
            if (timeSinceLastReload > timeBetweenReloads)
            {
                timeSinceLastReload = 0;
                curentAmmo++;
                if (curentAmmo == maxAmmo) isReloading = false;
            }
        }

        if (timeSinceHasFired > timeBetweenHasFired)
        {
            hasFired = false;
        }
    }
}