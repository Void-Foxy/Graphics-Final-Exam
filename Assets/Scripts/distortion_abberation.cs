using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[ExecuteInEditMode, ImageEffectAllowedInSceneView]
public class distortion_aberration : MonoBehaviour
{
    const int distortionPass = 0;
    public Shader distortionAberrationShader;
    [Range(-1f, 1f)]
    public float Distortion = 0.1f;
    [Range(0f, 10f)]
    public float Scale = 1f;
    [Range(-0.01f, 0.01f)]
    public float OffsetR = 0.001f;
    [Range(-0.01f, 0.01f)]
    public float OffsetG = 0.001f;
    [Range(-0.01f, 0.01f)]
    public float OffsetB = -0.001f;
    [NonSerialized]
    Material distAbMaterial;
    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (distAbMaterial == null)
        {
            distAbMaterial = new Material(distortionAberrationShader);
            distAbMaterial.hideFlags = HideFlags.HideAndDontSave;
        }
        distAbMaterial.SetFloat("_Distortion", Distortion);
        distAbMaterial.SetFloat("_Scale", Scale);
        distAbMaterial.SetFloat("_OffsetR", OffsetR);
        distAbMaterial.SetFloat("_OffsetG", OffsetG);
        distAbMaterial.SetFloat("_OffsetB", OffsetB);
        Graphics.Blit(source, destination, distAbMaterial, distortionPass);
    }
}