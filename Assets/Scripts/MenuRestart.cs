using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class MenuRestart : MonoBehaviour
{
    // Start is called before the first frame update    public Text puntuacion;
    public TextMeshProUGUI puntuacion;

    void Start(){
        puntuacion.text = puntuacion.text + " " + PlayerPrefs.GetString("PuntuacionActual");
    }
    public void Restart(){
       Time.timeScale = 1f;
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Back(){
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }
}
