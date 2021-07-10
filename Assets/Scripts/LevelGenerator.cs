using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEditorInternal;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public Texture2D map;

    private ObjectPool objects;

    // Start is called before the first frame update
    void Start()
    {
        objects = FindObjectOfType<ObjectPool>();
        GenerateLevel();
    }

    // Update is called once per frame
    void GenerateLevel()
    {
        for (int x = 0; x < map.width; x++)
        {
            for (int y = 0; y < map.height; y++)
            {
                Color pixelColor = map.GetPixel(x, y);
                Debug.Log(pixelColor);
                if (pixelColor.a != 0)
                {
                    objects.InstantiateObject(x,y, pixelColor);
                }
            }
        }
    }
    
}