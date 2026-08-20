using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEditor;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{    
    public bool gameState = true;
    public bool gameStateA = true;
    public bool gameStateB = true;
    private int multiplayer;
    public GameObject collidedObject;

    [SerializeField] private TextMeshProUGUI screenText;
    [SerializeField] private GameObject retryButton;
    [SerializeField] private GameObject menuButton;

    [SerializeField] private GameObject playerA;
    [SerializeField] private Camera playerACam;
    [SerializeField] private GameObject playerB;
    [SerializeField] private GameObject playerBCam;

    [SerializeField] private Vector3 playerSpawn;
    [SerializeField] private Vector3 multiplayerSpawn;

    void Awake()
    {
        retryButton.SetActive(false);
        menuButton.SetActive(false);

        // Get Multiplayer From Player Prefabs
        multiplayer = PlayerPrefs.GetInt("multiplayer");
        if (multiplayer == 0)
        {
            playerA.transform.position = playerSpawn;
            playerACam.rect = new Rect (0f, 0f, 1f, 1f);
            playerB.SetActive(false);
            playerBCam.SetActive(false);
        }
        else if (multiplayer == 1)
        {
            Debug.Log("Starting multiplayer");
            Debug.Log("Creating player 1");
            Debug.Log("Creating player 2");
            playerB.SetActive(true);
            playerBCam.SetActive(true);
            playerA.transform.position = multiplayerSpawn;
            playerACam.rect = new Rect (0f, 0f, 0.5f, 1f);
        }
    }

    void Update()
    {
    
        // Check if Player A is OOB
        if (playerA.transform.position.y < -30)
        {
            gameStateA = false;
            gameState = false;
        }

        // Check if Player B is OOB
        if (playerB.transform.position.y < -30)
        {
            gameStateB = false;
        }

        // Game Over State
        if (multiplayer == 0)
        {
            SoloWinGame();
            LoseGame();
        }

        if (multiplayer == 1)
        {
            MultiWinGame();
            MultiLoseGame();
        }

        if (!gameStateA && !gameStateB)
        {
            Debug.Log("Both Over");
            gameState = false;
            LoseGame();
        }

    }

    void SoloWinGame()
    {
        if (playerA.GetComponent<PlayerContoller>().winGame)
        {
            retryButton.SetActive(true);
            menuButton.SetActive(true);
            screenText.alignment = TextAlignmentOptions.Center;
            screenText.text = "You Win!";

            Invoke("Menu", 2f);
        }
    }

    void MultiWinGame()
    {
        // Check if Player A Wins
        if (playerA.GetComponent<PlayerContoller>().winGame)
        {
            retryButton.SetActive(true);
            menuButton.SetActive(true);
            screenText.alignment = TextAlignmentOptions.Center;
            screenText.text = "Player 1 Wins!";

            Invoke("Menu", 2f);
        }

        // Check if Player B Wins
        if (playerB.GetComponent<PlayerContoller>().winGame)
        {
            retryButton.SetActive(true);
            menuButton.SetActive(true);
            screenText.alignment = TextAlignmentOptions.Center;
            screenText.text = "Player 2 Wins!";

            Invoke("Menu", 2f);
        }

    }

    void LoseGame()
    {
        if (gameState == false)
        {
            retryButton.SetActive(true);
            menuButton.SetActive(true);
            screenText.text = "Game Over";
            screenText.alignment = TextAlignmentOptions.Center;
            playerA.GetComponent<PlayerContoller>().activeContols = false;
        }
    }

    void MultiLoseGame()
    {
        if (collidedObject == playerA && gameStateA)
        {
            screenText.text = "Game Over";
            screenText.alignment = TextAlignmentOptions.Left;
            playerA.GetComponent<PlayerContoller>().activeContols = false;
            gameStateA = false;

        } else if (collidedObject == playerB && gameStateB)
        {
            screenText.text = "Game Over";
            screenText.alignment = TextAlignmentOptions.Right;
            playerB.GetComponent<PlayerContoller>().activeContols = false;
            gameStateB = false;
        }
    }

    public void Retry()
    {
        SceneManager.LoadScene(1);
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
}
