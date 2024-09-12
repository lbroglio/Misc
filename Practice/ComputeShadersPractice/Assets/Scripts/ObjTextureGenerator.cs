using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;

public class ObjTextureGenerator : MonoBehaviour
{

    public ComputeShader TextureCreator;
    private RenderTexture _rText;


    // Set the texture for the sides of the attached game object to be a texure created by a compute shader
    private void SetTexture()
    {
        if(_rText == null)
        {
            MeshRenderer renderer = gameObject.GetComponent<MeshRenderer>();

            int sideLen = 1080;
            //Debug.Log(sideLen);


            _rText = new RenderTexture(sideLen, sideLen, 0, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Linear);
            _rText.enableRandomWrite = true;
            _rText.Create();

            int kernel = TextureCreator.FindKernel("CSMain");
            TextureCreator.SetTexture(kernel, "Result", _rText);
            TextureCreator.SetInt("SideLen", sideLen);
            int workgroupsX = Mathf.CeilToInt(sideLen / 8.0f);
            int workgroupsY = Mathf.CeilToInt(sideLen / 8.0f);
            TextureCreator.Dispatch(kernel, workgroupsX, workgroupsY, 1);

            Texture2D tmp = new Texture2D(sideLen, sideLen, TextureFormat.ARGB32, false);

            Graphics.CopyTexture(_rText, tmp);

            renderer.material.mainTexture = tmp;
        }
    }
   
    // Start is called before the first frame update
    void Start()
    {
        SetTexture();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
