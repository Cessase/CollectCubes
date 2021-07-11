using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCube : MonoBehaviour
{
    Renderer rend;

    private Color c;
    public Color C
    {
        get => c;
        set => c = value;
    }

    // Start is called before the first frame update
    void Awake()
    {
        rend = GetComponent<Renderer>();
    }

    private void OnEnable()
    {
        Color pixelColor = c;
        rend.material.color = pixelColor;
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
