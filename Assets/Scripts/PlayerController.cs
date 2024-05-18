using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class PlayerController : MonoBehaviour
{
    public float velocidad;
    public Text countText;
    public Text winText;

    private Rigidbody rb;
    private int contador;
    private bool isAndroid;

    public GameObject perdiste;
    public GameObject ganaste;

    public AudioSource sonidoMusica;
    public AudioSource sonidoMoneda;
    public AudioSource sonidoFresa;
    public AudioSource sonidoDiamante;
    public AudioSource sonidoGanar;
    public AudioSource sonidoPerder;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        contador = 0;
        SetCountText();
        winText.text = "";
        #if UNITY_ANDROID
            isAndroid = true;
        #else
            isAndroid = false;
        #endif
        sonidoMusica.loop = true;
        sonidoMusica.Play();


    }

    void FixedUpdate()
    {

        float posH;
        float posV;
        if(isAndroid){
            posH = Input.acceleration.x;
            posV = Input.acceleration.y;
        }
        else{
            posH = Input.GetAxis("Horizontal");
            posV = Input.GetAxis("Vertical");
        }

        // Movimiento del jugador
        Vector3 movimiento = new Vector3(posH, 0.0f, posV);
        if (rb.velocity.y > 0.0f) {
            rb.velocity = new Vector3(rb.velocity.x, 0.0f, rb.velocity.z);
        }

        rb.AddForce(movimiento * velocidad);
        // Debug.Log(rb.velocity);
    }

    void OnTriggerEnter(Collider other)
    {

    if (other.gameObject.CompareTag("Fresa"))
        {
            other.gameObject.SetActive(false);
            contador = contador + 3;
            sonidoFresa.Play();
            SetCountText();

        }
    if (other.gameObject.CompareTag("Moneda"))
        {
            other.gameObject.SetActive(false);
            contador = contador + 1;
            sonidoMoneda.Play();
            SetCountText();
        }
    if (other.gameObject.CompareTag("Diamante"))
        {
            other.gameObject.SetActive(false);
            contador = contador + 10;
            sonidoDiamante.Play();
            SetCountText();

        }
    if (other.gameObject.CompareTag("Portal"))
        {
            ganaste.SetActive(true);
            PlayerPrefs.SetString("PuntuacionActual", "" + contador);
            sonidoGanar.Play();
            Time.timeScale = 0f;
            if(sonidoMusica != null && sonidoMusica.isPlaying){
                sonidoMusica.Stop();
            }
        }
    if (other.gameObject.CompareTag("Murision"))
        {
            perdiste.SetActive(true);
            PlayerPrefs.SetString("PuntuacionActual", "" + contador);
            sonidoPerder.Play();
            Time.timeScale = 0f;
            if(sonidoMusica != null && sonidoMusica.isPlaying){
                sonidoMusica.Stop();
            }
            // winText.text = "Perdiste?!! :(";
            // Invoke("QuitGame", 1f);
        }
    }

    void SetCountText()
    {
        countText.text = "Contador: " + contador.ToString();
        // if (contador >= 4)
        // {
        //     winText.text = "Ganaste!!";
        // }
    }

    private void OnTriggerExit(Collider other)
    {


    }


    void QuitGame()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #elif UNITY_WEBPLAYER
                Application.OpenURL(webplayerQuitURL);
        #else
                Application.Quit();
        #endif
    }
}
