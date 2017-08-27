using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFallDownScript : MonoBehaviour
{
    private Rigidbody rBody;

    void Start()
    {
        this.rBody = this.gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (this.rBody.transform.position.y > 0)
        {
            this.rBody.AddForce(Vector3.down * 3 * Time.deltaTime);
        }
    }
}
