using System.Collections;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public MeshFilter filter;
    public Mesh mesh;

    public GameObject[] removeAditionally;

    private void Awake()
    {
        if(filter == null)
            filter = GetComponent<MeshFilter>();
        if(mesh == null)
            mesh = filter.mesh;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>() == null) return;
        filter.mesh = null;
        foreach (var o in removeAditionally)
            o.SetActive(false);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerController>() == null) return;
        filter.mesh = mesh;
        foreach (var o in removeAditionally)
            o.SetActive(true);
    }
}
