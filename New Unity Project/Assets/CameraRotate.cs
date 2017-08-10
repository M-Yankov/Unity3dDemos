using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public GameObject player;
    public GameObject rotateAroundtarget;
    public bool rotateCamera;

    private const float Radius = 80;
    private float timeCounter = 0;
    private bool riseUp = false;

    // Use this for initialization
    void Start()
    {
        PlayerScript playerScript = this.player.GetComponent<PlayerScript>();
        playerScript.tourEnded += PlayerScript_tourEnded;
    }

    private void PlayerScript_tourEnded(object sender, EventArgs e)
    {
        Debug.Log("End!");
        this.riseUp = true;
    }

    // Update is called once per frame
    void Update()
    {
        timeCounter += Time.deltaTime;
        float x = Mathf.Cos(timeCounter) * Radius;
        float y = this.transform.position.y;
        float z = Mathf.Sin(timeCounter) * Radius;


        PlayerScript playerScript = this.player.GetComponent<PlayerScript>();
        if (this.riseUp && this.transform.position.y < 40)
        {
            this.transform.Translate(Vector3.up * Time.deltaTime * playerScript.speed);
            return;
        }
        else if (this.transform.position.y >= 40)
        {
            //this.transform.position = new Vector3(x, y, z);
            this.transform.Translate(Vector3.right);
            this.transform.LookAt(this.rotateAroundtarget.transform);
        }

        if (playerScript.IsReady && !playerScript.IsTourEnded)
        {
            this.transform.LookAt(this.player.transform);

            this.transform.Translate(Vector3.forward * Time.deltaTime * playerScript.speed);
            this.transform.position = new Vector3(this.transform.position.x, y, this.transform.position.z);
        }
        else if (!playerScript.IsReady)
        {
            this.transform.LookAt(this.player.transform);

            this.transform.Translate(new Vector3(0, 0, 1) * Time.deltaTime * (playerScript.speed / 3));
            this.transform.position = new Vector3(this.transform.position.x, y, this.transform.position.z);
        }


        // works fine - finish this.
            
        if (this.rotateCamera && false)
        {
            this.transform.position = new Vector3(x, y, z);
            this.transform.LookAt(Vector3.zero);
        }
    }
}
