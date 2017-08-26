using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5;
    public GameObject cameraObject;
    public UnityEngine.UI.Text healthText;
    public float mouseSensitive = 1;
    public float defense = 50;

    public float health = 100;
    private Vector3 horizontalMovement;
    private Vector3 verticalMovemnt;
    private Rigidbody rBody;
    private bool isDeath = false;

    // Use this for initialization
    void Start()
    {
        rBody = this.gameObject.GetComponent<Rigidbody>();
        Cursor.visible = false;
    }

    private void Update()
    {
        if (this.isDeath)
        {
            return;
        }

        if (Input.GetKey("up") || Input.GetKey("w"))
        {
            this.verticalMovemnt = this.transform.forward * speed;
        }
        else if (Input.GetKey("down") || Input.GetKey("s"))
        {
            this.verticalMovemnt = -this.transform.forward * speed;
        }
        else
        {
            this.verticalMovemnt = Vector3.zero;
        }

        if (Input.GetKey("left") || Input.GetKey("a"))
        {
            this.horizontalMovement = -this.transform.right * speed;
        }
        else if (Input.GetKey("right") || Input.GetKey("d"))
        {
            this.horizontalMovement = this.transform.right * speed;
        }
        else
        {
            this.horizontalMovement = Vector3.zero;
        }
    }

    void FixedUpdate()
    {
        if (this.isDeath)
        {
            RespawingState respawnState = this.gameObject.GetComponent<RespawnScript>().GetState();
            if (this.rBody.transform.rotation.eulerAngles.x >= 270f && respawnState == RespawingState.RespawnFinished)
            {
                this.gameObject.GetComponent<RespawnScript>().Respawn();
            }
            else if(respawnState == RespawingState.RespawnFinished)
            {
                // make body lying like death
                const float deathSpeed = 6f;
                Quaternion deathPosition = Quaternion.Euler(270f, 0, 0);
                this.rBody.rotation = Quaternion.Slerp(transform.localRotation, deathPosition, Time.deltaTime * deathSpeed);
            }
            return;
        }

        //this.rBody.AddForce(movement * speed);
        Vector3 move = this.horizontalMovement + this.verticalMovemnt;
        this.rBody.velocity = move;

        float horizontalMouseMove = Input.GetAxis("Mouse X");
        float verticalMouseMove = Input.GetAxis("Mouse Y");

        this.rBody.rotation = Quaternion.Euler(this.rBody.rotation.eulerAngles + new Vector3(0, horizontalMouseMove * this.mouseSensitive, 0));

        // move only camera up-down
        this.cameraObject.transform.Rotate(new Vector3(verticalMouseMove * this.mouseSensitive * -1, 0, 0));
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "EnemyBullet")
        {
            BulletScript bulletScript = collision.gameObject.GetComponent<BulletScript>();
            float damage = bulletScript.damage - (this.defense / 100);
            this.health -= damage;
            if (this.health < 0)
            {
                this.health = 0;
            }

            this.UpdateHealth();

            Destroy(collision.gameObject);
            if (this.health <= 0)
            {
                // Destroy(this.gameObject);
                this.rBody.constraints = RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
                this.isDeath = true;
            }
        }
    }

    public void UpdateHealth()
    {
        if (this.health >= 0)
        {
            this.healthText.text = this.health.ToString();
        }

        if (this.health < 20f)
        {
            this.healthText.color = Color.red;
        }
        else
        {
            this.healthText.color = Color.green;
        }
    }

    public bool IsAlive()
    {
        return !this.isDeath;
    }

    public void SetAlive(bool isAlive)
    {
        this.isDeath = !isAlive;
    }
}
