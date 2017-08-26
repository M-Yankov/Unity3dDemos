using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 0.5f;
    public float damage = 70f;
    void Start()
    {

    }

    void Update()
    {
        this.transform.position += this.transform.forward * this.speed * Time.deltaTime;
    }
}
