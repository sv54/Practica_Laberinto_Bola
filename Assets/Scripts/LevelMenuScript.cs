using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenuScript : MonoBehaviour
{    
    private static LevelMenuScript instancia;

    public AudioSource sonidoMusicaMenu;

    void Start()
    {

        sonidoMusicaMenu.Play();

    }
    public void Play1()
    {
        sonidoMusicaMenu.Stop();
        SceneManager.LoadScene(2);
        
    }
    public void Play2()
    {
        sonidoMusicaMenu.Stop();
        SceneManager.LoadScene(3);
    }
    public void Play3()
    {
        sonidoMusicaMenu.Stop();
        SceneManager.LoadScene(4);
    }
    public void Play4()
    {
        sonidoMusicaMenu.Stop();
        SceneManager.LoadScene(5);
    }
    public void Play5()
    {
        sonidoMusicaMenu.Stop();
        SceneManager.LoadScene(6);
    }
    public void Back()
    {
        sonidoMusicaMenu.Stop();
        SceneManager.LoadScene(0);
    }
}
