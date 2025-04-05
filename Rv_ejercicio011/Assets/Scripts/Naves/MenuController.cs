using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class MenuController : MonoBehaviour
{
    private Camera xRCamera;// Variable para guardar la c�mara
    // Start is called before the first frame update
    void Start() // Inicia solo al empezar el juego
    {
        xRCamera = CameraPointerManager.instance.gameObject.GetComponent<Camera>(); // Llamando a la clase CameraPointerManager como instance en UIElements;
    }

    public void menu_principal() // Carga la escena Menu_Principal
    {
        SceneManager.LoadScene("Menu_principal");
    }

    public void reiniciar() // Carga la escena Juego principal
    {
        SceneManager.LoadScene("Ejercicio05-naves");
    }

    public void game_over() // Carga la escena Menu Game Over
    {
        SceneManager.LoadScene("Menu_Game_Over");
    }

    public void OnPointerClick() // Funci�n que simula un clic en el objeto desde el c�digo
    {
        PointerEventData pointerEvent = PlacePointer(); // Este es el elemento que nos permitira hacer clic sobre el elemento UI
        ExecuteEvents.Execute(this.gameObject, pointerEvent, ExecuteEvents.pointerClickHandler); // Ejecutamos el Evento al hacer clic
    }

    public PointerEventData PlacePointer() // Funci�n que crea un puntero en la posici�n de la pantalla donde el jugador est� mirando o tocando
    {
        Vector2 screenPos = xRCamera.WorldToScreenPoint(CameraPointerManager.instance.hitPoint); // Convitiendo posici�n del mundo a posici�n en la pantalla
        var pointer = new PointerEventData(EventSystem.current); // Creando nuevo puntero
        pointer.position = new Vector2(screenPos.x, screenPos.y); // Ubicacion del puntero en pantalla
        return pointer; // Devolviendo el puntero
    }
}
