using UnityEngine;

public class SpereScript : MonoBehaviour
{

    private Rigidbody myRigitBody;

    // Use this for initialization
    void Start()
    {
        this.myRigitBody = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            this.myRigitBody.AddForce(this.transform.forward, ForceMode.Impulse);
        }
    }
}
