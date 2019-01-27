using System;
using UnityEngine;

[ExecuteInEditMode]
public class DizzinessEffect : MonoBehaviour
{
    public float Multiplier;
    public float Dizziness;
    public float Threshold;

    private Material mat;

    private string lastKey;

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
            if (lastKey == "a")
            {
                Dizziness = Mathf.Lerp(Dizziness, -Dizziness, Time.deltaTime/100);
            }
            else if (Dizziness < 0)
                lastKey = "d";
        }

        if (Input.GetKey("a"))
        {
            if (Dizziness < Threshold)
                Dizziness += Multiplier;
            Rotate(-Dizziness);
            if (lastKey == "d")
            {
                Dizziness = Mathf.Lerp(Dizziness, -Dizziness, Time.deltaTime/100);
            }
            else if(Dizziness < 0)
                lastKey = "a";
        }

        if (!Input.anyKey)
        {
            var tmp = Dizziness;
            tmp = Mathf.Lerp(lastKey == "d" ? tmp : lastKey == "a" ? -tmp : 0, 0, Time.deltaTime);
            Dizziness = Math.Abs(tmp);
            Rotate(tmp);
        }
        
    }

    void Rotate(float angle)
    {
        Camera.main.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
