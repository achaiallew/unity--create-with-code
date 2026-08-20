using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Tutorial Panel Declaration
    [SerializeField] private GameObject tutorialPanel;
    [SerializeField] private Toggle toggle;

    void Awake()
    {
        tutorialPanel.SetActive(false);
        PlayerPrefs.SetInt("multiplayer", 0);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void OpenTutorial()
    {
        tutorialPanel.SetActive(true);
    }

    public void CloseTutorial()
    {
        tutorialPanel.SetActive(false);
    }

    public void ToggleMultiplayer()
    {
        if (toggle.isOn == true)
        {
            PlayerPrefs.SetInt("multiplayer", 1);
        }
        else
        {
            PlayerPrefs.SetInt("multiplayer", 0);
        }
        
    }



}
