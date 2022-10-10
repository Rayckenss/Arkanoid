using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool paused;
    public bool win;
    public player player;
    public List<GameObject> boxes;
    public float ballSpeed;
    public GameObject powerUpPrefab;
    public float probabilidad;

    [Header("Pause")]
    public GameObject pausedMenu;
    public GameObject warningPaused;

    [Header("Options")]
    public GameObject optionMenu;
    public GameObject modeSelect;
    public Button gameMode;
    bool mode;

    [Header("interfaz")]
    public GameObject endGame;
    public GameObject winGame;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    private void Start()
    {
        paused = false;
        win = false;
        pausedMenu.SetActive(false);
        warningPaused.SetActive(false);
        endGame.SetActive(false);
        mode = true;
        if (mode)
        {
            gameMode.GetComponentInChildren<TMP_Text>().text = "Mouse";
            player.control = player.Control.Mouse;
        }
    }
    private void Update()
    {
        PauseButton();
        if (boxes.Count==0)
        {
            win = true;
            winGame.SetActive(true);
        }
    }

    public void PauseButton()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
        }
        if (paused)
        {
            pausedMenu.SetActive(true);
        }
    }
    public void Buttons(int button)
    {
        switch (button)
        {
            case 1:
                //Continue button
                paused = false;
                pausedMenu.SetActive(false);
                break;
            case 2:
                //Seleccionar modo de juego
                mode = !mode;
                if (mode)
                {
                    gameMode.GetComponentInChildren<TMP_Text>().text = "Mouse";
                    player.control = player.Control.Mouse;
                }
                else
                {
                    gameMode.GetComponentInChildren<TMP_Text>().text = "Keyboard";
                    player.control = player.Control.Keyboard;
                }
                break;
            case 3:
                //Retry nutton
                SceneManager.LoadScene(1);
                break;
            case 4:
                //options
                optionMenu.SetActive(true);
                break;
            case 5:
                //Exit options
                optionMenu.SetActive(false);
                break;
            case 6:
                //exit pause
                warningPaused.SetActive(true);
                break;
            case 7:
                //paused warning yes
                SceneManager.LoadScene(0);
                break;
            case 8:
                //pause warning no
                warningPaused.SetActive(false);
                break;
            default:
                break;
        }
    }

}
