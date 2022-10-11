using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public AudioSource musicaFondo;
    public Slider volumen;
    public Slider sensibility;

    [Header("Play Menu")]
    public GameObject playMenu;

    [Header("Options Menu")]
    public GameObject optionMenu;
    public GameObject sliderSens;

    [Header("Exit Menu")]
    public GameObject exitMenu;



    private void Start()
    {
        musicaFondo.volume = Options.globalVolumen;
        volumen.value = Options.globalVolumen;

        sensibility.value = Options.sensibility;
    }

    private void Update()
    {
        musicaFondo.volume = Options.globalVolumen;
        Options.globalVolumen = volumen.value;

        Options.sensibility = sensibility.value;
    }
    public void MenuButtons(int num)
    {
        switch (num)
        {
            case 0:
                //Play button
                playMenu.SetActive(true);
                break;
            case 1:
                //Option Button
                optionMenu.SetActive(true);
                break;
            case 2:
                //Exit Button
                exitMenu.SetActive(true);
                break;
            case 3:
                // Nivel 1
                SceneManager.LoadScene(1);
                break;
            case 4:
                //Nivel 2
                SceneManager.LoadScene(2);
                break;
            case 5:
                //Nivel 3
                SceneManager.LoadScene(3);
                break;
            case 6:
                //Nivel 4
                SceneManager.LoadScene(4);
                break;
            case 7:
                //Nivel 5
                SceneManager.LoadScene(5);
                break;
            case 8:
                //salida play menu
                playMenu.SetActive(false);
                break;
            case 9:
                //salida opciones
                optionMenu.SetActive(false);
                break;
            case 10:
                //salida exit
                exitMenu.SetActive(false);
                break;
            case 11:
                //Salida juego
                Application.Quit();
                break;
            default:
                break;
        }
    }
    public void DropDownProblemn(int value)
    {
        if (value==0)
        {
            Options.modoDeJuego = 0;
            sliderSens.SetActive(false);
        }
        if (value==1)
        {
            Options.modoDeJuego = 1;
            sliderSens.SetActive(true);
        }
    }
}
