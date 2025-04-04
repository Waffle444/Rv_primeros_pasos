using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameControllerNaves : MonoBehaviour
{
    public Camera gameCamera;
    public GameObject bulletPrefab;
    public GameObject enemyPrefab;
    [SerializeField] GameObject menu;
    [SerializeField] TMP_Text puntaje;
    public MenuController MenuController;
    public float enemySpawningCooldown = 1f;
    public float enemySpawningDistance = 7f;
    public float shootingCooldown = 0.5f;

    private float enemySpawningTimer = 0;
    private float shootingTimer = 0;
    private int npuntaje = 0;
    // Use this for initialization
    void Start()
    {
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Enemy")
        {
            MenuController.menu_principal();
        }
    }
    void Update()
    {
        shootingTimer -= Time.deltaTime;
        enemySpawningTimer -= Time.deltaTime;

        if (enemySpawningTimer <= 0f && menu.activeSelf != true)
        {
            enemySpawningTimer = enemySpawningCooldown;
            GameObject enemyObject = Instantiate(enemyPrefab);
            float randomAngle = UnityEngine.Random.Range(0, Mathf.PI * 2);
            enemyObject.transform.position = new Vector3(
                gameCamera.transform.position.x + Mathf.Cos(randomAngle) * enemySpawningDistance,
                gameCamera.transform.position.y,
                gameCamera.transform.position.z + Mathf.Sin(randomAngle) * enemySpawningDistance
            );

            Enemy enemy = enemyObject.GetComponent<Enemy>();
            enemy.direction = (gameCamera.transform.position - enemy.transform.position).normalized;
            enemy.transform.LookAt(Vector3.zero);
        }

        RaycastHit hit;
        if (Physics.Raycast(gameCamera.transform.position, gameCamera.transform.forward, out hit))
        {
            if (hit.transform.tag == "Enemy" && shootingTimer <= 0f)
            {
                shootingTimer = shootingCooldown;

                GameObject bulletObject = Instantiate(bulletPrefab);
                bulletObject.transform.position = gameCamera.transform.position;
                Bullet bullet = bulletObject.GetComponent<Bullet>();
                bullet.direction = gameCamera.transform.forward;

                npuntaje += 100;
                puntaje.text = "Puntaje: " + npuntaje;
            }
        }
    }
}