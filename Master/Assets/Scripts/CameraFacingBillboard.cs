using UnityEngine;

public class CameraFacingBillboard : MonoBehaviour
{
    private Camera camera;

    void Start()
    {
        camera = Camera.main;
    }

    void LateUpdate()
    {
        transform.LookAt(transform.position + camera.transform.rotation * Vector3.forward, camera.transform.rotation * Vector3.up);
    }
}