
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject cube;
    [SerializeField] private int poolSize;

    private GameObject[,] pool;

    // Start is called before the first frame update
    void Awake()
    {
        PopulatePool();
    }

    // ReSharper disable Unity.PerformanceAnalysis
    public void InstantiateObject(int i,int j, Color c)
    {
        float x = -1.5f + i * 0.1f;
        float z = 0f + j * 0.1f;
        pool[i,j].transform.position = new Vector3(x,0.525f,z);
        pool[i,j].GetComponent<ColorCube>().C = c;
        pool[i,j].SetActive(true);
    }

    void PopulatePool()
    {
        pool = new GameObject[poolSize,poolSize];
        
        for (int i = 0; i < poolSize; i++)
        {
            for (int j = 0; j < poolSize; j++)
            {
                pool[i,j] = Instantiate(cube, transform);
                pool[i,j].SetActive(false);
            }
        }
    }

    public void DisableObjectsForNextLevel()
    {
        for (int i = 0; i < poolSize; i++)
        {
            for (int j = 0; j < poolSize; j++)
            {
                pool[i,j].SetActive(false);
                pool[i,j].layer = 0;
            }
        }
    }
}
