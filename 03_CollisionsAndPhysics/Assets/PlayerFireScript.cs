using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireScript : MonoBehaviour
{
    public GameObject bulletSpawnPoint;
    public GameObject bulletTemplate;
    public float fireRate = 1.5f;
    private float timePassed;

    void Start()
    {
       
    }

    void Update()
    {
      
        this.timePassed += Time.deltaTime;
        if (this.timePassed > this.fireRate && Input.GetMouseButton(0))
        {
            this.timePassed = 0;

            GameObject bullet = Instantiate(bulletTemplate, this.bulletSpawnPoint.transform.position, this.bulletSpawnPoint.transform.rotation);
            GameObject[] doors = GameObject.FindGameObjectsWithTag("Door");
            foreach (GameObject door in doors)
            {
                Physics.IgnoreCollision(door.GetComponent<Collider>(), bullet.GetComponent<Collider>());
            }

            Destroy(bullet, 5);
        }
    }
}
