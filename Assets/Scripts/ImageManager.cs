using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ImageManager : MonoBehaviour
{

    string _basePath;
    public static ImageManager Instance;
    // Start is called before the first frame update
    void Start()
    {
        if(Instance != null)
        {
            GameObject.Destroy(this);
            return;

        }
        Instance = this;

        _basePath = Application.persistentDataPath + "/Pictures/";
        if (!Directory.Exists(_basePath))
        {
            Directory.CreateDirectory(_basePath);
        }
  
    } //Start

    bool imageExists(string name)
    {
        return File.Exists(_basePath + name);
    }

   public void SaveImage(string name, byte[] bytes)
    {
        File.WriteAllBytes(_basePath + name, bytes);
    }

   public byte[] LoadImage(string name)
    {
        byte[] bytes = new byte[0];
        if (imageExists(name))
        {
            bytes = File.ReadAllBytes(_basePath + name);
        }
        return bytes;
    }//Load Image

    public Sprite bytesToSprite(byte[] bytes)
    {
        //Create 2D texture
        Texture2D texture = new Texture2D(2, 2);
        texture.LoadImage(bytes);

        //create sprite (in the future will be placed in UI)
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        return sprite;
    }
}
