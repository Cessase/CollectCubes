using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Image progress;
    // Start is called before the first frame update
    void Start()
    {
        progress.fillAmount = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FillProgressBar()
    {
        progress.fillAmount++;
    }
    
}
