using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Corona : MonoBehaviour {

	public GameObject camera;
	public GameObject camada1;
	public GameObject camada2;
	public GameObject camada3;
	public GameObject camada4;
	public GameObject camada5;
	public GameObject camada6;

	public Text txtVidas;
	private static int vidas = 5;

	public AudioSource som1;
	public AudioSource som2;

	// Use this for initialization
	void Start () {
		som1 = GetComponents<AudioSource> () [1];
		som2 = GetComponents<AudioSource> () [0];
	}

	// Update is called once per frame
	void Update () {
		txtVidas.text = "Vidas: " + vidas;
	}

	void OnCollisionEnter (Collision item) {
		som1.Play ();
	}

	void OnTriggerEnter (Collider item) {
		if (item.gameObject.CompareTag ("vermelho")) {
			// Rinicia o jogo
			som2.Play ();
			InvokeRepeating ("Reiniciar", 0.5f, 1);
		} else if (item.gameObject.CompareTag ("azul")) {
			// Passa de fase
			if (camada1.activeSelf) {
				NextPhase (camada1);
			} else if (camada2.activeSelf) {
				NextPhase (camada2);
			} else if (camada3.activeSelf) {
				NextPhase (camada3);
			} else if (camada4.activeSelf) {
				NextPhase (camada4);
			} else if (camada5.activeSelf) {
				NextPhase (camada5);
			}
		} else if (item.gameObject.CompareTag ("ganhou")) {
			SceneManager.LoadScene ("scene-003");
		}
	}

	private void Reiniciar () {
		vidas--;

		if (vidas > 0) {
			SceneManager.LoadScene ("scene-001");
		} else {
			SceneManager.LoadScene ("scene-002");
		}
	}

	private void NextPhase (GameObject gameObject) {
		gameObject.SetActive (false);

		var covid = transform.position;
		covid.y -= 45f;

		transform.position = covid;

		var camPos = camera.transform.position;
		camPos.y -= 50f;

		camera.transform.position = camPos;
	}
}