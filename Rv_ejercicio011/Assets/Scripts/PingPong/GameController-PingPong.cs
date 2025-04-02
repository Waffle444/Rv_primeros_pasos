using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;

public class GameControllerPingPong : MonoBehaviour {

    public PlayerPingPong player;
	public Ball ball;
	public TextMeshProUGUI scoreText;
    public GameObject menu_gameover;

    private float gameOverTimer = 3f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		bool isGameOver = ball.transform.position.z < player.transform.position.z;

        if (isGameOver == false)
        {
            scoreText.text = "Score: " + ball.score;
        }
        else
        {
            scoreText.text = "Game over!\nYour final score: " + ball.score;
            menu_gameover.SetActive(true);
        }
    }
    public void reinicio()
    {
        Debug.Log("se reinicio");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ManinMenu()
    {  
        Debug.Log("Se regreso");
        SceneManager.LoadScene("MainMenu");
    }
    public void IniciarJuego()
    {
        SceneManager.LoadScene("Ejercicio03-juego-VR-Pong");
    }
    public void CerrarJuego()
    {
        Debug.Log("El juego se cerrará.");
        Application.Quit();
    }
}
