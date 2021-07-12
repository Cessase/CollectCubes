
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private Canvas exitGameUI;
    [SerializeField] private Button yesButton;
    [SerializeField] private Button noButton;

    // Update is called once per frame
    private void Update()
    {
        yesButton.onClick.AddListener(ExitGame);
        noButton.onClick.AddListener(StayInGame);
        
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void StayInGame()
    {
        exitGameUI.gameObject.SetActive(false);
    }
}
