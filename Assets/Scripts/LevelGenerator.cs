
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public Texture2D[] maps;
    private ObjectPool objects;
    
    private float cubesInLevel; 
    public float CubesInLevel { get => cubesInLevel; set => cubesInLevel = value; }
    private int level = 0; public int Level { get => level; set => level = value; }

    // Start is called before the first frame update
    void Start()
    {
        objects = FindObjectOfType<ObjectPool>();
        GenerateLevel();
    }

    // Update is called once per frame
    void GenerateLevel()
    {
        for (int x = 0; x < maps[level].width; x++)
        {
            for (int y = 0; y < maps[level].height; y++)
            {
                Color pixelColor = maps[level].GetPixel(x, y);
                //Debug.Log(pixelColor);
                if (pixelColor.a != 0)//if transparent
                {
                    objects.InstantiateObject(x,y, pixelColor);
                    cubesInLevel++;
                }
            }
        }
        
    }

    public void LoadNextLeveL()
    {
        cubesInLevel = 0;
        objects.DisableObjectsForNextLevel();
        if (level < maps.Length)
        {
            GenerateLevel();
        }
    }
    
}