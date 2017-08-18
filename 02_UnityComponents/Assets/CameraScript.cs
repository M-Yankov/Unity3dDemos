using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float spped = 5;

    private GameObject player;
    private Vector3 offset;
    private float cameraScrollSpeed = 5;
    private float maxCameraZoomInZ = 0;
    private float maxCameraZoomIOutZ = -12;

    void Start()
    {
        this.player = GameObject.FindGameObjectWithTag(CustomTags.Player);
        this.offset = this.player.transform.position - this.transform.position;       
    }
    
    void Update()
    {
        float mouseWheel = Input.GetAxis(BuildInAxis.MouseScrollWheel);
        if (mouseWheel != 0)
        {
            if (mouseWheel > 0 && this.transform.position.z < maxCameraZoomInZ)
            {
                this.offset = this.offset + (Vector3.back * Time.deltaTime * cameraScrollSpeed);
            }
            else if( mouseWheel < 0 && this.transform.position.z > maxCameraZoomIOutZ)
            {
                this.offset = this.offset - (Vector3.back * Time.deltaTime * cameraScrollSpeed);
            }
        }

        this.transform.position = this.player.transform.position - this.offset;
    }
}
