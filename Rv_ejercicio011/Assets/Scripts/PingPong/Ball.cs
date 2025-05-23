﻿using UnityEngine;
using System.Collections;
using TMPro;

public class Ball : MonoBehaviour {

	public PlayerPingPong player;
	public float speed = 2.5f;
	public float speedIncrement = 0.5f;
	public float deflectionDepth = 6f;
	public float deflectionRadius = 2f;
	public float rotatingSpeed = 50f;
	[SerializeField] TextMeshProUGUI textHighScore;
	public Vector3 direction;
	public int highScore;
	[SerializeField] Animator anim;

	public int score = 0;

	// Use this for initialization
	void Start () {
        GazeManager.Instance.OnGazeSelection += OnPlayerHit;
		highScore = PlayerPrefs.GetInt("HighScore", 0);
		textHighScore.text="Score Maximo:"+highScore.ToString();
    }
	
	// Update is called once per frame
	void Update () {
		transform.position += direction.normalized * speed * Time.deltaTime;

		if (transform.position.z >= deflectionDepth && direction.z > 0) {

			float randomAngle = Random.Range (0f, 2 * Mathf.PI);

			Vector3 targetPosition = new Vector3 (
				player.transform.position.x + Mathf.Cos(randomAngle) * deflectionRadius,
				player.transform.position.y + Mathf.Sin(randomAngle) * deflectionRadius,
				player.transform.position.z
			);

			direction = (targetPosition - transform.position).normalized;
		}

		// Rotating logic.
		transform.RotateAround(transform.position, Vector3.up, rotatingSpeed * Time.deltaTime);
		transform.RotateAround(transform.position, Vector3.right, rotatingSpeed * Time.deltaTime);
		transform.RotateAround(transform.position, Vector3.forward, rotatingSpeed * Time.deltaTime);
	}

	public void OnPlayerHit () {
		if (transform.position.z > player.transform.position.z) {
			direction *= -1;

			speed += speedIncrement;
			anim.SetBool("raquet",true);
			score++;
			if(PlayerPrefs.GetInt("HighScore",0)<score)
			{
				PlayerPrefs.SetInt("HighScore",score);
			}
			
		}
        anim.SetBool("raquet", false);
    }
}
