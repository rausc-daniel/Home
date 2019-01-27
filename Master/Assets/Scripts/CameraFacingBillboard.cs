using UnityEngine;

public class CameraFacingBillboard : MonoBehaviour
{
    private Camera camera;

    void Start()
    {
        DoorMiniGame.onLockFinished += () => camera = Camera.main;
    }

    void LateUpdate()
    {
        if(camera != null)
        transform.LookAt(transform.position + camera.transform.rotation * Vector3.forward, camera.transform.rotation * Vector3.up);
    }
}