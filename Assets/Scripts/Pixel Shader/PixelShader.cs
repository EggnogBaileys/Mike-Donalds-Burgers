using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelShader : MonoBehaviour
{
    //courtesy of El Esclavo de el Juego

    public Material mat;

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, mat);
    }
}
