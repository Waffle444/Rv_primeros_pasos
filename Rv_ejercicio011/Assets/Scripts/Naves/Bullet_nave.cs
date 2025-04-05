using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_nave : MonoBehaviour // Clase que controla el comportamiento de la bala
{
    public float speed = 1f; // Velocidad de la bala
    public Vector3 direction; // Direcci�n en la que se mueve la bala
    private float lifetime = 2f; // Tiempo de vida de la bala antes de ser destruida

    void Update() // M�todo que se ejecuta una vez por frame
    {
        transform.position += direction * speed * Time.deltaTime; // Mueve la bala en la direcci�n y velocidad especificada
        lifetime -= Time.deltaTime; // Resta tiempo al contador de vida de la bala
        if (lifetime < 0) // Si la bala ha vivido m�s de lo permitido
        {
            Destroy(gameObject); // Destruye la bala
        }
    }

    void OnTriggerEnter(Collider other) // M�todo que detecta colisiones
    {
        if (other.gameObject.tag == "Enemy") // Si el objeto con el que colide tiene el tag "Enemy"
        {
            Destroy(other.gameObject); // Destruye el objeto enemigo
            Destroy(gameObject); // Destruye la bala
        }
    }
}
