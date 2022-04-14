using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Rewired;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MacchininaBase : MonoBehaviour {
	public float currentSpeed;
	static protected int totalCheckPoints;
	protected int touchedCheckPoints;
	public int lap;
	public List<GameObject> touchedCheckpoints = new List<GameObject>();
	public Action onLap;
	protected ParticleSystem particleSystem;
	protected AudioSource bonk;
	private bool isBreaking=false;
	public float maxSpeed;
	public float minSpeed;
	public float steeringspeed;
	public float accelerationDelta;
	public int position;
	private RaycastHit hitCheckpoint;
	private Coroutine reverseCoru;
	public float distanceToNextCheckPoint;

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
		if (Physics.Raycast(transform.position, transform.forward, out hitCheckpoint, Mathf.Infinity, LayerMask.GetMask("CheckPoint"))) {
			distanceToNextCheckPoint = hitCheckpoint.distance;
			if (touchedCheckpoints.Contains(hitCheckpoint.collider.gameObject)&&touchedCheckpoints.Last()!=hitCheckpoint.collider.gameObject) {
				if (this is MacchinaController) {
					if (reverseCoru==null) {
						reverseCoru=StartCoroutine(turnAround());
					}
				}
				else {
					if (reverseCoru==null) {
						reverseCoru=StartCoroutine(turnAroundPlayer());
					}
				}
				Debug.Log("reverse");
			}
		}
	}

	public IEnumerator turnAround() {
		yield return new WaitForSeconds(0.3f);
		transform.localRotation=Quaternion.Euler(transform.localRotation.eulerAngles.x,transform.localRotation.eulerAngles.y+180,transform.localRotation.eulerAngles.z);
		yield return new WaitForSeconds(0.2f);
		reverseCoru = null;
	}	
	public IEnumerator turnAroundPlayer() {
		LapManager.Instance.giro.text = "REVERSE";
		LapManager.Instance.giro.CrossFadeAlpha(1,0.2f,true);
		yield return new WaitForSeconds(0.7f);
		LapManager.Instance.giro.CrossFadeAlpha(0,0,true);
		LapManager.Instance.giro.text = "Giro Completo!";
		transform.localRotation=Quaternion.Euler(transform.localRotation.eulerAngles.x,transform.localRotation.eulerAngles.y+180,transform.localRotation.eulerAngles.z);
		reverseCoru = null;
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