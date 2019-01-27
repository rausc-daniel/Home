using UnityEngine;
using UnityEngine.UI;

public delegate void OnLockFinished();
public class DoorMiniGame : MonoBehaviour
{
    public static event OnLockFinished onLockFinished;

    public GameObject schloss;
    public GameObject keyHole;
    public GameObject key;
    public Image bar;
    public Camera mainCam;
    public Camera doorCam;

    void Start()
    {
        ActivateDoor();
        //DoorOpened();
    }

    public void ActivateDoor()
    {
        schloss.SetActive(true);
        keyHole.SetActive(true);
        key.SetActive(true);
        bar.transform.gameObject.SetActive(true);
        mainCam = Camera.main;
        mainCam.tag = "Respawn";
        doorCam.tag = "MainCamera";

    }

    public void DoorOpened()
    {
        Destroy(schloss);
        Destroy(keyHole);
        Destroy(key);
        Destroy(bar);
        mainCam.tag = "MainCamera";
        Destroy(doorCam.gameObject);
        onLockFinished.Invoke();
    }
}
