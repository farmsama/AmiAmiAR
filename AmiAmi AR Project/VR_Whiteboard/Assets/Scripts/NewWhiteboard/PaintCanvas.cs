using UnityEngine;

public class PaintCanvas : MonoBehaviour
{
    public static Texture2D Texture { get; private set; }
    
    // original texture
    public static Texture2D originalTexture;
       

    //public static byte[] GetAllTextureData()
    //{
    //    return Texture.GetRawTextureData();
    //}

    private void Start()
    {
        PrepareTemporaryTexture();
    }

    private void PrepareTemporaryTexture()
    {
        Texture = (Texture2D)GameObject.Instantiate(GetComponent<Renderer>().material.mainTexture);
        GetComponent<Renderer>().material.mainTexture = Texture;

        originalTexture = (Texture2D)GameObject.Instantiate(GetComponent<Renderer>().material.mainTexture);
    }

    internal static void SetAllTextureData(byte[] textureData)
    {
        Texture.LoadRawTextureData(textureData);
        Texture.Apply();
    }
}