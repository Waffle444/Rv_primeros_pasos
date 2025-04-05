using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 1f; // Asignamos la velocidad de la nave enemiga
    public Vector3 direction; // Asignar la direcion a la que va el enemigo en tres puntos x,y,z
    // Start is called before the first frame update
    void Start() // inica solo al empezar el juego 
    {
        
    }

    // Update is called once per frame
    void Update() //Actualiza todo el rato
    {
        transform.position += direction * speed * Time.deltaTime; //Permite mover al enemigo en una direcion con una velocidad constante
    }
}
