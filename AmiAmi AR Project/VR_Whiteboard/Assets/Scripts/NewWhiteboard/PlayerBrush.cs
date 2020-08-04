using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBrush : MonoBehaviour
{
    public bool isDrawing = true;
    public float raydist = 1f;
    int fuckyourfloat = 1;
    Color fuckyourcolor = Color.black;

    UI_BrushSizeSlider BrushSize;
    ColorPicker BrushColor;

    public GameObject BrushSettingGrp;

    private void Start()
    {
        //var data = PaintCanvas.GetAllTextureData();
        //var zippeddata = data.Compress();
    }

    private void FixedUpdate()
    {
        
    }


    private void Update()
    {
        if (BrushSettingGrp.activeSelf == true)
        {
            //SDebug.Log("active");

            BrushSize = FindObjectOfType<UI_BrushSizeSlider>();
            BrushColor = FindObjectOfType<ColorPicker>();

            // Converting float to Int
            fuckyourfloat = Convert.ToInt32(BrushSize.slider.value);

            fuckyourcolor = BrushColor.CurrentColor;
        }

        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 8;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, raydist, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");

            var pallet = hit.collider.GetComponent<PaintCanvas>();
            if (pallet != null)
            {
                Debug.Log(hit.textureCoord);
                Debug.Log(hit.point);

                Renderer rend = hit.transform.GetComponent<Renderer>();
                MeshCollider meshCollider = hit.collider as MeshCollider;

                if (rend == null || rend.sharedMaterial == null || rend.sharedMaterial.mainTexture == null || meshCollider == null)
                    return;

                Texture2D tex = rend.material.mainTexture as Texture2D;
                Vector2 pixelUV = hit.textureCoord;
                pixelUV.x *= tex.width;
                pixelUV.y *= tex.height;

                BrushAreaWithColor(pixelUV, fuckyourcolor, fuckyourfloat);
            }
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * raydist, Color.white);
            //Debug.Log("Did not Hit");
        }
        
        //   if (Input.GetMouseButton(0))
        //   {
        //       Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //
        //       RaycastHit hit;
        //       if (Physics.Raycast(ray, out hit))
        //       {
        //           var pallet = hit.collider.GetComponent<PaintCanvas>();
        //           if (pallet != null)
        //           {
        //               Debug.Log(hit.textureCoord);
        //               Debug.Log(hit.point);
        //           
        //               Renderer rend = hit.transform.GetComponent<Renderer>();
        //               MeshCollider meshCollider = hit.collider as MeshCollider;
        //           
        //               if (rend == null || rend.sharedMaterial == null || rend.sharedMaterial.mainTexture == null || meshCollider == null)
        //                   return;
        //           
        //               Texture2D tex = rend.material.mainTexture as Texture2D;
        //               Vector2 pixelUV = hit.textureCoord;
        //               pixelUV.x *= tex.width;
        //               pixelUV.y *= tex.height;
        //           
        //               BrushAreaWithColor(pixelUV, ColorPicker.SelectedColor, BrushSizeSlider.BrushSize);
        //           }
        //       }
        //   }
    }


    private void BrushAreaWithColor(Vector2 pixelUV, Color color, int size)
    {
        for (int x = -size; x < size; x++)
        {
            for (int y = -size; y < size; y++)
            {
                if (isDrawing)
                {
                    //Check if color is the same
                    Color currColor = PaintCanvas.Texture.GetPixel((int)pixelUV.x + x, (int)pixelUV.y + y);

                    if (currColor != color)
                    {
                        PaintCanvas.Texture.SetPixel((int)pixelUV.x + x, (int)pixelUV.y + y, color);
                    }
                }
                else
                {
                    // Erase version
                    Color originalColor = PaintCanvas.originalTexture.GetPixel((int)pixelUV.x + x, (int)pixelUV.y + y);
                    PaintCanvas.Texture.SetPixel((int)pixelUV.x + x, (int)pixelUV.y + y, originalColor);
                }
            }
        }

        PaintCanvas.Texture.Apply();
    }
}