using System.Collections;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private MeshFilter filter;
    private Mesh mesh;

    private void Awake()
    {
        filter = GetComponent<MeshFilter>();
        mesh = filter.mesh;
    }

    private void OnTriggerEnter(Collider other)
    {
        filter.mesh = null;
    }

    private void OnTriggerExit(Collider other)
    {
        filter.mesh = mesh;
    }
}
