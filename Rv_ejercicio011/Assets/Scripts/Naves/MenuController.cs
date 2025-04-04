using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class MenuController : MonoBehaviour
{
    private Camera xRCamera;
    // Start is called before the first frame update
    void Start()
    {
        xRCamera = CameraPointerManager.instance.gameObject.GetComponent<Camera>();
    }

    public void menu_principal()
    {
        SceneManager.LoadScene("Menu_principal");
    }

    public void reiniciar()
    {
        SceneManager.LoadScene("Ejercicio05-naves");
    }

    public void game_over()
    {
        SceneManager.LoadScene("Menu_Game_Over");
    }

    public void OnPointerClick()
    {
        PointerEventData pointerEvent = PlacePointer(); // Este es el elemento que nos permitira hacer clic sobre el elemento UI
        ExecuteEvents.Execute(this.gameObject, pointerEvent, ExecuteEvents.pointerClickHandler); // Ejecutamos el Evento al hacer clic
    }

    public PointerEventData PlacePointer()
    {
        Vector3 screePos = xRCamera.WorldToScreenPoint(CameraPointerManager.instance.hitPoint);
        var pointer = new PointerEventData(EventSystem.current);
        pointer.position = new Vector2(screePos.x, screePos.y);
        return pointer;
    }
}
