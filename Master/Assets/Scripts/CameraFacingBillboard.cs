using UnityEngine;

public class CameraFacingBillboard : MonoBehaviour
{
    public Camera camera;

    void LateUpdate()
    {
        transform.LookAt(transform.position + camera.transform.rotation * Vector3.forward, camera.transform.rotation * Vector3.up);
    }
}