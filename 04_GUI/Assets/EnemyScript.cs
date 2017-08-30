using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    public float aimSpeed = 0.4f;
    public float defense = 3;
    public float health = 100;
    public float bonusScore = 10;

    private GameObject player;
    private Rigidbody rBody;
    private Slider healthSlider;
    private GameObject scoreHandler;

    void Start()
    {
        this.player = GameObject.FindGameObjectWithTag("Player");
        this.rBody = this.gameObject.GetComponent<Rigidbody>();
        this.healthSlider = GetComponentInChildren<Slider>();
        this.scoreHandler = GameObject.FindGameObjectWithTag("ScoreManager");

        this.healthSlider.maxValue = this.health;
        this.healthSlider.value = this.health;
        this.healthSlider.minValue = 0;
    }

    void Update()
    {
        if (this.player != null)
        {
            Vector3 direction = this.player.transform.position - this.transform.position;
            this.rBody.rotation = Quaternion.Slerp(this.rBody.rotation, Quaternion.LookRotation(direction), this.aimSpeed * Time.deltaTime);

            // Health bar always rotated to player
            this.healthSlider.transform.rotation = Quaternion.LookRotation(this.player.transform.position - this.gameObject.transform.position);
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
            
            UpdateUIHealth(this.health);
            Destroy(collision.gameObject);
            if (this.health < 0)
            {
                Destroy(this.gameObject);
                this.scoreHandler.GetComponent<ScoreManagerScript>().AddScore(this.bonusScore);
            }
        }
    }

    protected virtual void UpdateUIHealth(float health)
    {
        if (this.healthSlider.minValue <= health && health <= this.healthSlider.maxValue)
        {
            this.healthSlider.value = health;
        }
    }
}
