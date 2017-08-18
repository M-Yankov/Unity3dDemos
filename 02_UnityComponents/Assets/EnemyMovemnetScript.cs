using System;
using UnityEngine;

public class EnemyMovemnetScript : MonoBehaviour
{
    public float speed = 4;
    public float playerDistanceX = 2;
    public event EventHandler<EventArgs> targetReached;
    private GameObject player;
    private bool playerReached = false;

    void Start()
    {
        this.player = GameObject.FindGameObjectWithTag(CustomTags.Player);
    }

    void Update()
    {
        float distance = Mathf.Abs(this.player.transform.position.z - this.transform.position.z);
        if (distance > playerDistanceX)
        {
            this.transform.Translate(Vector3.back * Time.deltaTime * speed);
        }
        else if (!playerReached)
        {
            // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/events/how-to-raise-base-class-events-in-derived-classes
            EventHandler<EventArgs> handler = this.targetReached;
            if (handler != null)
            {
                handler(this, new EventArgs());
            }

            playerReached = true;
        }
        
    }
}
