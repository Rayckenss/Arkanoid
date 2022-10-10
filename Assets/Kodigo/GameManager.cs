using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Parametros de juego")]
    public player player;
    public bool paused;
    public bool win;
    public List<GameObject> boxes;
    public float ballSpeed;
    public GameObject powerUpPrefab;
    public float probabilidad;

    [Header("Audio")]
    public AudioSource musicaFondo;
    public Slider volumen;

    [Header("Pause")]
    public GameObject pausedMenu;
    public GameObject warningPaused;

    [Header("Options")]
    public GameObject optionMenu;
    public GameObject sliderGameMode;

    [Header("interfaz")]
    public GameObject endGame;
    public GameObject winGame;
    public TMP_Text reloj;
    public TMP_Text puntaje;
    int puntos;

    [Header("Reloj")]
    [Tooltip("Tiempo iniciar en Segundos")]
    public int tInicial;
    [Tooltip("Escala del Tiempo del Reloj")]
    [Range(-10.0f, 10.0f)]
    public float escalaDeTiempo = 1;
    private float tFrameTScale = 0f;
    private float tEnSegundos = 0F;
    private float escalatiempoPausa, escalaTInicial;



    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            Debug.Log(this.name);
        }
    }
    private void Start()
    {
        paused = false;
        win = false;
        pausedMenu.SetActive(false);
        warningPaused.SetActive(false);
        endGame.SetActive(false);
        sliderGameMode.SetActive(false);
        musicaFondo.volume = Options.globalVolumen;
        volumen.value = Options.globalVolumen;
        ModoDeJuego();

        //reloj
        escalaTInicial = escalaDeTiempo;
        tEnSegundos = tInicial;
        ActualizarReloj(tInicial);

    }
    private void Update()
    {
        PauseButton();
        ModoDeJuego();
        musicaFondo.volume = Options.globalVolumen;
        Options.globalVolumen = volumen.value;
        if (boxes.Count==0)
        {
            win = true;
            winGame.SetActive(true);
        }

        //reloj
        tFrameTScale = Time.deltaTime * escalaDeTiempo;
        tEnSegundos += tFrameTScale;
        ActualizarReloj(tEnSegundos);

    }
    public void ModoDeJuego()
    {
        if (Options.modoDeJuego == 0)
        {
            player.control = player.Control.Mouse;
        }
        if (Options.modoDeJuego == 1)
        {
            player.control = player.Control.Keyboard;
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
    public void DropDownProblemn(int value)
    {
        if (value == 0)
        {
            Options.modoDeJuego = 0;
            sliderGameMode.SetActive(false);
        }
        if (value == 1)
        {
            Options.modoDeJuego = 1;
            sliderGameMode.SetActive(true);
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
    void ActualizarReloj(float tiempo)
    {
        int minutos = 0;
        int segundos = 0;
        //int milisegundos=0;
        string textoDelReloj;
        if (tiempo < 0) tiempo = 0;
        minutos = (int)tiempo / 60;
        segundos = (int)tiempo % 60;
        //milisegundos=(int)tiempo/1000;
        textoDelReloj = minutos.ToString("00") + ":" + segundos.ToString("00");//+ ":" + milisegundos.ToString("00");
        reloj.text = textoDelReloj;

    }
    public void PuntajeEnPantalla(int punt)
    {
        puntos += punt;
        string pnt;
        pnt = puntos.ToString("000");
        puntaje.text = pnt;
    }

}
