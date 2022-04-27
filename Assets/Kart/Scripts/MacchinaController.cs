using System.Collections;
using BehaviorDesigner.Runtime;
using UnityEngine;

public class MacchinaController : MacchininaBase {
	private BehaviorTree tree;
	public float breakTreshold;
	public float decelerateTreshold;

	// Start is called before the first frame update
	IEnumerator Start() {
		float temp;
		temp = Random.Range(0.01f, 0.09f);
		steeringspeed += temp;
		temp = Random.Range(0.001f, 0.009f);
		accelerationDelta += temp;
		temp = Random.Range(0.1f, 0.9f);
		maxSpeed += temp;
		base.Start();
		onLap += OnFinish;
		tree = GetComponent<BehaviorTree>();
		tree.enabled = false;
		tree.SetVariableValue("VelocityIncrement", accelerationDelta);
		tree.SetVariableValue("SteeringSpeed", steeringspeed);
		tree.SetVariableValue("BreakTreshold", breakTreshold);
		tree.SetVariableValue("StopAccelerateTreshold", decelerateTreshold);
		yield return new WaitForSeconds(LapManager.Instance.start.length);
		tree.enabled = true;
	}

	private void OnDisable() {
		onLap -= OnFinish;
	}

	private void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.CompareTag("Muri")) {
			base.OnCollisionEnter(collision);
			tree.SetVariableValue("CurrentSpeed", currentSpeed);
		}
	}

	private void OnFinish() {
		Debug.Log(lap + " cpu");
		if (lap==LapManager.Instance.maxLap) {
			LapManager.Instance.sfx.PlayOneShot(LapManager.Instance.playerLose);
		}
	}

	private void Update() {
		tree.SetVariableValue("CurrentSpeed",currentSpeed);
		base.Update();
	}
}