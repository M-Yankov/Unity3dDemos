using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float aimSpeed = 0.4f;
    public float defense = 3;
    public float health = 100;
    private GameObject player;

    private Rigidbody rBody;

    void Start()
    {
        this.player = GameObject.FindGameObjectWithTag("Player");
        this.rBody = this.gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (this.player != null)
        {
            Vector3 direction = this.player.transform.position - this.transform.position;
            this.rBody.rotation = Quaternion.Slerp(this.rBody.rotation, Quaternion.LookRotation(direction), this.aimSpeed * Time.deltaTime);
        }
        else
        {
            this.player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            BulletScript bulletScript = collision.gameObject.GetComponent<BulletScript>();
            float damage =bulletScript.damage - (this.defense / 100);
            this.health -= damage;

            Destroy(collision.gameObject);
            if (this.health < 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
