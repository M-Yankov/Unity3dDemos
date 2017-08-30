using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour
{

    void Start()
    {
        this.transform.Translate(Vector3.back * 100 * Time.deltaTime);
    }

    void Update()
    {

    }
}
