using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyfireScript : MonoBehaviour
{
    public GameObject bulletSpawnPoint;
    public GameObject bulletTemplate;
    public float fireTimeInSeconds = 1;

    private float currentTime = 0;
    private GameObject player;

    void Start()
    {
        this.player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        PlayerController playerController = this.player.GetComponent<PlayerController>();
        currentTime += Time.deltaTime;

        if (currentTime > this.fireTimeInSeconds && playerController.IsAlive())
        {
            GameObject bullet = Instantiate(this.bulletTemplate, this.bulletSpawnPoint.transform.position, this.bulletSpawnPoint.transform.rotation);
            Destroy(bullet, 3);
            currentTime = 0;
        }
    }
}
