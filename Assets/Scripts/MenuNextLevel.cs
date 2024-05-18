using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuNextLevel : MonoBehaviour
{

    public TextMeshProUGUI puntuacion;

    void Start()
    {
        puntuacion.text = puntuacion.text + " " + PlayerPrefs.GetString("PuntuacionActual");

    }
    public void Next()
    {
        Time.timeScale = 1f;
        if (SceneManager.GetActiveScene().buildIndex < 6)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else{
            SceneManager.LoadScene(0);
        }


    }

    public void Back()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

}
