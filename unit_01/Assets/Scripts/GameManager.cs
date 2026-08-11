using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{    
    public bool gameState = true;
    [SerializeField] private TextMeshProUGUI screenText;
    [SerializeField] private GameObject retryButton;
    
    void Update()
    {
        if (gameState == false)
        {
            retryButton.SetActive(true);
            screenText.text = "Game Over";
        }
    }

    public void Retry()
    {
        SceneManager.LoadScene(0);
    }
}
