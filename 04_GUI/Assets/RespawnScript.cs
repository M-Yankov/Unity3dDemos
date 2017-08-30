using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnScript : MonoBehaviour
{
    public float respawnSeconds = 3f;
    public float respawnHeight = 30f;

    private RespawingState respawnState = RespawingState.RespawnFinished;
    private float currentTime = 0f;
    private Rigidbody rBody;

    void Start()
    {
        this.rBody = this.gameObject.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (this.respawnState == RespawingState.StartRespawn)
        {
            this.currentTime += Time.deltaTime;
        }

        if (this.respawnState == RespawingState.Respawning)
        {
            this.rBody.AddForce(this.rBody.transform.up * -1, ForceMode.Force);
            Vector3 currentAngles = this.rBody.transform.rotation.eulerAngles;
            if (currentAngles.x != 0 || currentAngles.y != 0 || currentAngles.z != 0)
            {
                this.transform.rotation = Quaternion.Euler(0, this.rBody.rotation.eulerAngles.y, this.rBody.rotation.eulerAngles.z);
            }
        }

        if (this.currentTime > this.respawnSeconds)
        {
            // hide respawn message
            PlayerController playerController = this.GetComponent<PlayerController>();
            playerController.respawnText.enabled = false;

            this.respawnState = RespawingState.Respawning;
            this.rBody.transform.position = new Vector3(this.rBody.transform.position.x, this.respawnHeight, this.rBody.transform.position.z);
            this.currentTime = 0;
        }

        if (this.rBody.transform.position.y <= 1 && this.respawnState == RespawingState.Respawning)
        {
            this.respawnState = RespawingState.RespawnFinished;
            this.rBody.useGravity = true;
           
            this.rBody.constraints = RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX;
            PlayerController playerController = this.GetComponent<PlayerController>();
            playerController.SetAlive(true);
            playerController.health = 100f;
            playerController.UpdateHealth();
        }
    }

    public void Respawn()
    {
        if (this.respawnState == RespawingState.RespawnFinished)
        {
            this.respawnState = RespawingState.StartRespawn;
        }
    }

    public RespawingState GetState()
    {
        return this.respawnState;
    }
}

public enum RespawingState
{
    StartRespawn = 1,
    Respawning = 2,
    RespawnFinished = 3,
}
