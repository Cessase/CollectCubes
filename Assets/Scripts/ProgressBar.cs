using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Image progressBar;
    [SerializeField] private Button nextLevelButton;
    [SerializeField] private TextMeshProUGUI currentlevelText;
    [SerializeField] private TextMeshProUGUI nextlevelText;
    [SerializeField][Range(0f,1f)] private  float requiredProgressforNextLevel;
    [SerializeField] private Canvas endScreen;
    
    
    private LevelGenerator levelGen;
    public event Action nextLevel;
    
    public float totalCubesRescued;
    private float progress;
    private bool canSkipNextLevel = false;
    private bool cooldown;

    // Start is called before the first frame update
    void Start()
    {
        levelGen = FindObjectOfType<LevelGenerator>();
        nextLevelButton.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLevel();
        FillProgressBar();
        NextLevelButtonController();
    }

    public void UpdateLevel()
    {
        currentlevelText.text = (levelGen.Level +1).ToString();
        nextlevelText.text = (levelGen.Level + 2).ToString();
        
    }
    

    public void FillProgressBar()
    {
        progress = totalCubesRescued / levelGen.CubesInLevel;
        progressBar.fillAmount = progress;
        //Debug.Log(progress);
        if (progress > requiredProgressforNextLevel)
        {
            canSkipNextLevel = true;
        }
    }

    void NextLevelButtonController()
    {
        if (levelGen.Level < 4)
        {
            if (cooldown == false)
            {
                nextLevelButton.onClick.AddListener(SkipNextLevel);
                Invoke("ResetCooldown", 2.0f);
                cooldown = true;
            }
        }
        else
        {
            endScreen.gameObject.SetActive(true);
            Time.timeScale = 0;
        }

        ColorButton();
    }

    private void ColorButton()
    {
        if (canSkipNextLevel)
        {
            if (nextLevelButton.enabled == false)
            {
                nextLevelButton.GetComponentInChildren<Image>().color = Color.magenta;
            }

            nextLevelButton.enabled = true;
        }
        else if (!canSkipNextLevel)
        {
            if (nextLevelButton.enabled == true)
            {
                nextLevelButton.GetComponentInChildren<Image>().color = Color.white;
            }

            nextLevelButton.enabled = false;
        }
    }

    void ResetCooldown(){
        cooldown = false;
    }

    void SkipNextLevel()
    {
        nextLevel();
        
            if (canSkipNextLevel)
                {
                levelGen.Level++;
                levelGen.LoadNextLeveL();
                canSkipNextLevel = false;
                totalCubesRescued = 0;
                } 
        
        
        
    }
    
    

}
