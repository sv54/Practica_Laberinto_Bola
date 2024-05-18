using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{

    public AudioSource sonidoMusicaMenu;
    private static MainMenuScript instancia;
    void Start()
    {
        sonidoMusicaMenu.Play();
    }
    public void Play(){
       SceneManager.LoadScene(1);
    }

    public void Quit(){
        Application.Quit();
    }
}
