using UnityEngine;

public class PlayerBrush :MonoBehaviour
{
    public bool isDrawing = true;

    private void Start()
    {
        //var data = PaintCanvas.GetAllTextureData();
        //var zippeddata = data.Compress();
 
    }


    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
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

                    BrushAreaWithColor(pixelUV, ColorPicker.SelectedColor, BrushSizeSlider.BrushSize);
                }
            }
        }
    }
    

  
    private void BrushAreaWithColor(Vector2 pixelUV, Color color, int size)
    {
        for (int x = -size; x < size; x++)
        {
            for (int y = -size; y < size; y++)
            {
                if (isDrawing)
                {
                    PaintCanvas.Texture.SetPixel((int)pixelUV.x + x, (int)pixelUV.y + y, color);
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