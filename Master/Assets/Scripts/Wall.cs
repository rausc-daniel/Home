using System.Collections;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private Material mat;

    private void Awake()
    {
        mat = GetComponent<MeshRenderer>().material;
    }

    private void OnTriggerEnter(Collider other)
    {
        mat.color = new Color(mat.color.r, mat.color.g, mat.color.b, 0.00001f);
    }

    private void OnTriggerExit(Collider other)
    {
        mat.color = new Color(mat.color.r, mat.color.g, mat.color.b, 1f);
    }
}
