using UnityEngine;

public class GunScript : MonoBehaviour
{
    public float fireRateInSeconds = 0.5f;
    public GameObject bullet;

    private Transform bulletSpawnPoint;
    private float secondsSinceLastFire = 0;
    private float lifeTimeOfBuller = 0.5f;

    void Start()
    {
        bulletSpawnPoint = GameObject.FindGameObjectWithTag(CustomTags.BulletSpawnPoint).transform;
    }

    void Update()
    {
        this.secondsSinceLastFire += Time.deltaTime;
        if (this.secondsSinceLastFire > this.fireRateInSeconds && Input.GetAxis(BuildInAxis.Fire1) > 0)
        {
            GameObject newBullet = Instantiate(bullet, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation);
            Destroy(newBullet, this.lifeTimeOfBuller);
            this.secondsSinceLastFire = 0;
        }
    }
}
