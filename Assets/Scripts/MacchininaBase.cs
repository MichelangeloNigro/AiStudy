using System;
using System.Collections;
using System.Collections.Generic;
using Rewired;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MacchininaBase : MonoBehaviour {
	public float currentSpeed;
	static protected int totalCheckPoints;
	protected int touchedCheckPoints;
	public int lap;
	protected List<GameObject> touchedCheckpoints = new List<GameObject>();
	public Action onLap;
	protected ParticleSystem particleSystem;
	protected AudioSource bonk;
	private bool isBreaking=false;
	public float maxSpeed;
	public float minSpeed;
	public float steeringspeed;
	public float accelerationDelta;

	public void Accelerate(InputActionEventData data) {
		if (!isBreaking) {
			currentSpeed += accelerationDelta;
			currentSpeed = Mathf.Clamp(currentSpeed, minSpeed, maxSpeed);
		}
	}

	public void Break(InputActionEventData data) {
		currentSpeed -= accelerationDelta * 3;
		currentSpeed = Mathf.Clamp(currentSpeed, minSpeed, maxSpeed);
		isBreaking = true;
	}

	public void stopBreaking(InputActionEventData data) {
		isBreaking = false;
	}

	public void Decelerate(InputActionEventData data) {
		if (!isBreaking) {
			currentSpeed -= accelerationDelta * 2;
			currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed);
		}
	}

	protected void Start() {
		totalCheckPoints = GameObject.FindGameObjectsWithTag("CheckPoint").Length;
		onLap += CheckWin;
		particleSystem = GetComponent<ParticleSystem>();
		bonk = GetComponent<AudioSource>();
	}

	protected void Update() {
		var emission = particleSystem.emission;
		emission.rateOverTime = currentSpeed;
	}

	protected void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.CompareTag("Muri")) {
			bonk.Play();
			currentSpeed = 0;
		}
	}

	private void OnTriggerEnter(Collider other) {
		if (other.CompareTag("CheckPoint") && !touchedCheckpoints.Contains(other.gameObject)) {
			touchedCheckPoints++;
			touchedCheckpoints.Add(other.gameObject);
		}
		if (other.CompareTag("Finish") && touchedCheckPoints == totalCheckPoints) {
			touchedCheckpoints.Clear();
			touchedCheckPoints = 0;
			lap++;
			onLap();
		}
	}

	protected void OnDisable() {
		onLap -= CheckWin;
	}

	public IEnumerator win() {
		Time.timeScale = 0;
		LapManager.Instance.winnerText.gameObject.SetActive(true);
		LapManager.Instance.winnerText.text = gameObject.name + " Won";
		LapManager.Instance.music.Stop();
		yield return new WaitForSecondsRealtime(10f);
		SceneManager.LoadScene("MainMenu");
	}

	private void CheckWin() {
		if (lap == LapManager.Instance.maxLap) {
			StartCoroutine(win());
		}
	}
}