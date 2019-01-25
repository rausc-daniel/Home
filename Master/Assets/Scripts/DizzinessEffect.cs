using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class DizzinessEffect : MonoBehaviour
{
    public float Multiplier;
    public float Dizziness;
    public float Threshold;

    private Material mat;

    void Awake()
    {
        mat = new Material(Shader.Find("Custom/Dizziness"));
    }

    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        mat.SetFloat("_Dizziness", Dizziness);
        mat.SetFloat("_ElapsedTime", Time.time);
        mat.SetFloat("_DeltaTime", Time.deltaTime);
        Graphics.Blit(source, destination, mat);
    }

    void Update()
    {
        if (Input.GetKey("d"))
        {
            if(Dizziness < Threshold)
                Dizziness += Multiplier;
            Rotate(Dizziness);
        }

        if (Input.GetKey("a"))
        {
            if (Dizziness > -Threshold)
                Dizziness -= Multiplier;
            Rotate(Dizziness);
        }

        if (!Input.anyKey)
        {
            Dizziness = Dizziness > 0.1 ? Dizziness - Multiplier * 2 : Dizziness < -0.1 ? Dizziness + Multiplier * 2 : 0;
            Rotate(Dizziness);
        }
        
    }

    void Rotate(float angle)
    {
        Camera.main.transform.rotation = Quaternion.AngleAxis(Dizziness, Vector3.forward);
    }
}
