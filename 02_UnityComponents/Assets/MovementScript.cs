using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public float speed = 5;

    void Start()
    {
    }

    private void FixedUpdate()
    {
        var x = Input.GetAxis(BuildInAxis.Horizontal) * speed * Time.deltaTime;
        //var y = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        float rotationValue = Input.GetAxis(BuildInAxis.MouseX);

        if (rotationValue != 0)
        {
            if (rotationValue < 0)
            {
                // left
                float yValue = this.transform.rotation.eulerAngles.y;
                if (0 <= yValue && yValue < 100)
                {
                    yValue = 360;
                }

                if (yValue + (rotationValue * speed) > 270)
                {
                    this.transform.Rotate(0, rotationValue * speed, 0);
                }
            }
            else if (rotationValue > 0)
            {
                // right
                float yValue = this.transform.rotation.eulerAngles.y;
                if (260 <= yValue && yValue < 360)
                {
                    yValue = 0;
                }

                if (yValue + (rotationValue * speed) < 90)
                {
                    this.transform.Rotate(0, rotationValue * speed, 0);
                }
            }
        }

        // Ngative - left
        // Positive - right
        if (x != 0)
        {
            if (x < 0)
            {
                this.transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
            }
            else
            {
                this.transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
            }
        }
    }
}
