using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject target;
    public float speed;

    public event EventHandler<EventArgs> tourEnded;

    private bool isReady = false;
    private bool isTourEnded = false;
    private bool isDemoFinished = false;

    private const int CollisionOffset = 2;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (this.isDemoFinished)
        {
            return;
        }

        if (this.transform.localRotation.eulerAngles.x > 0 && !this.isReady)
        {
            this.transform.Rotate(0.5f, 0, 0);
        }
        else
        {
            this.isReady = true;
        }

        if (this.isReady && !this.isTourEnded)
        {
            // This is the colligiion detection
            // Ofcourse there is a better way. It will be learned in next lection
            bool isInXRange = this.transform.position.x - CollisionOffset <= this.target.transform.position.x && this.target.transform.position.x <= this.transform.position.x + CollisionOffset;
            bool isInZRange = this.transform.position.z - CollisionOffset <= this.target.transform.position.z && this.target.transform.position.z <= this.transform.position.z + CollisionOffset;
            if (isInXRange && isInZRange)
            {
                TargetScript targetScript = this.target.GetComponent<TargetScript>();
                if (targetScript.nextTarget != null)
                {
                    this.target = targetScript.nextTarget;
                    Debug.Log("Target switched!");
                }
                else
                {
                    this.isTourEnded = true;
                }
            }

            this.transform.LookAt(this.target.transform);
            this.transform.Translate(Vector3.forward * Time.deltaTime * this.speed);
        }

        // pattern
        if ((this.transform.localRotation.eulerAngles.x < 1 ||
            this.transform.localRotation.eulerAngles.x > 270) &&
            this.isTourEnded)
        {
            this.transform.Rotate(-0.5f, 0, 0);
        }
        else if (this.isTourEnded)
        {
            this.isDemoFinished = true;
        }

        if (this.isDemoFinished)
        {
            // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/events/how-to-raise-base-class-events-in-derived-classes
            EventHandler<EventArgs> handler = this.tourEnded;
            if (handler != null)
            {
                handler(this, new EventArgs());
            }
        }
    }

    public bool IsReady
    {
        get
        {
            return this.isReady;
        }
    }

    public bool IsTourEnded
    {
        get
        {
            return this.isTourEnded;
        }
    }
}
