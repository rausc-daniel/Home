using System.Collections;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private MeshFilter filter;
    private Mesh mesh;
    public GameObject[] disableAditionally;

    private void Awake()
    {
        filter = GetComponent<MeshFilter>();
        mesh = filter.mesh;
    }

    private void OnTriggerEnter(Collider other)
    {
        filter.mesh = null;
        foreach (var o in disableAditionally)
            o.SetActive(false);
}

    private void OnTriggerExit(Collider other)
    {
        filter.mesh = mesh;
        foreach (var o in disableAditionally)
            o.SetActive(true);
    }
}
