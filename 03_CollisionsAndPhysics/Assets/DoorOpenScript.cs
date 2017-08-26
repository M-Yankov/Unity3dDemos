using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenScript : MonoBehaviour
{
    public float doorSpeed = 6.5f;
    public float doorCloseDistance = 15f;

    private DoorState doorState = DoorState.Closed;
    private HashSet<GameObject> objectsInteracted = new HashSet<GameObject>();
    private GameObject lastObjectInteracted;
    private Rigidbody rBody;

    // Use this for initialization
    void Start()
    {
        this.rBody = this.gameObject.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (this.doorState == DoorState.Opening) //this.doorState == DoorState.Closed
        {
            this.rBody.isKinematic = false;
            this.doorState = DoorState.Opening;
            var doorOpen = Quaternion.Euler(0, 93f, 0);
            this.rBody.rotation = Quaternion.Slerp(transform.localRotation, doorOpen, Time.deltaTime * this.doorSpeed);
        }

        if (this.doorState == DoorState.Closing) // this.doorState == DoorState.Opened
        {
            this.rBody.isKinematic = false;
            this.doorState = DoorState.Closing;
            var doorClose = Quaternion.Euler(0, 0f, 0);
            this.rBody.rotation = Quaternion.Slerp(transform.localRotation, doorClose, Time.deltaTime * this.doorSpeed);
        }

        SwitchDoorState();
    }

    void Update()
    {
        if (this.lastObjectInteracted != null)
        {
            float distance = Vector3.Distance(this.lastObjectInteracted.transform.position, this.transform.position);
            if (distance >= this.doorCloseDistance)
            {
                this.doorState = DoorState.Closing;
            }
        }    
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            return;
        }

        if (collision.gameObject.tag == "Player")
        {
            this.objectsInteracted.Add(collision.gameObject);
            this.lastObjectInteracted = null;
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (Input.GetMouseButton(0) && doorState == DoorState.Closed)
        {
            this.doorState = DoorState.Opening;
        }

        if (collision.gameObject.tag == "Player")
        {
            this.lastObjectInteracted = null;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (objectsInteracted.Count == 1)
        {
            this.lastObjectInteracted = collision.gameObject;
        }

        this.objectsInteracted.Remove(collision.gameObject);
    }

    private void SwitchDoorState()
    {
        if (this.rBody.rotation.eulerAngles.y >= 90f)
        {
            this.rBody.isKinematic = true;
            this.doorState = DoorState.Opened;
        }

        if (this.rBody.rotation.eulerAngles.y <= 0.1f)
        {
            this.rBody.isKinematic = true;
            this.doorState = DoorState.Closed;
            this.lastObjectInteracted = null;
        }
    }
}

public enum DoorState
{
    Opened = 1,
    Opening = 2,
    Closing = 3,
    Closed = 4,
}
