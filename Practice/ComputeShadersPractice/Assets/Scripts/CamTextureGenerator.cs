using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureGenerator : MonoBehaviour
{
    public ComputeShader TexureComputeShader;
    private RenderTexture _rText;


    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if( _rText == null)
        {
            _rText = new RenderTexture(Screen.width, Screen.height, 0, RenderTextureFormat.ARGBFloat, RenderTextureReadWrite.Linear);
            _rText.enableRandomWrite = true;
            _rText.Create();

            int kernel = TexureComputeShader.FindKernel("CSMain");
            TexureComputeShader.SetTexture(kernel, "Result", _rText);
            int workgroupsX = Mathf.CeilToInt(Screen.width / 8.0f);
            int workgroupsY = Mathf.CeilToInt(Screen.height / 8.0f);
            TexureComputeShader.Dispatch(kernel, workgroupsX, workgroupsY, 1);
            Graphics.Blit(_rText, destination);

        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
