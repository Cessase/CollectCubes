using System;

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
    [SerializeField] private Button exitButton;
    [SerializeField] private GameObject exitGameUI;
    [SerializeField] private float progress;
    private LevelGenerator levelGen;
    public event Action nextLevel;
    
    public float totalCubesRescued;
    private bool canSkipNextLevel = false;
    private bool cooldown;

    // Start is called before the first frame update
    void Start()
    {
        levelGen = FindObjectOfType<LevelGenerator>();
        nextLevelButton.enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateLevel();
        FillProgressBar();
        NextLevelButtonController();
        EndLevelOnFullProgress();
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
        if (progress > requiredProgressforNextLevel)
        {
            Debug.Log(totalCubesRescued + " " + levelGen.CubesInLevel);
            canSkipNextLevel = true;
        }
    }

    // ReSharper disable Unity.PerformanceAnalysis
    void NextLevelButtonController()
    {
        if (levelGen.Level < 4)
        {
            if (cooldown == false)
            {
                nextLevelButton.onClick.AddListener(SkipNextLevel);
                exitButton.onClick.AddListener(ShowExitMenu);
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

    void EndLevelOnFullProgress()
    {
        if (progress >= 1f)
            {
                canSkipNextLevel = true;
                Invoke("SkipNextLevel", 3.0f);
            }

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
    
    void ShowExitMenu()
    {
        exitGameUI.SetActive(true);
    }
    
    

}
