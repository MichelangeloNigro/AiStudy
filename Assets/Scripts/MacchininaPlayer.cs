using System;
using System.Collections;
using System.Collections.Generic;
using Rewired;
using UnityEngine;

public class MacchininaPlayer : MacchininaBase {
	private Player Player;
	public float maxSpeed;
	public float minSpeed;
	public float steeringspeed;
	public float accelerationDelta;
	private Rigidbody rb;

	// Start is called before the first frame update
	IEnumerator Start() {
		float temp = maxSpeed;
		float temp2 = minSpeed;
		maxSpeed = 0;
		minSpeed = 0;
		base.Start();
		onLap += OnFinish;
		rb = GetComponent<Rigidbody>();
		Player = ReInput.players.GetPlayer(0);
		Player.AddInputEventDelegate(Accelerate, UpdateLoopType.Update, InputActionEventType.ButtonPressed,
			RewiredConsts.Action.Accelerate);
		Player.AddInputEventDelegate(Break, UpdateLoopType.Update, InputActionEventType.ButtonPressed,
			RewiredConsts.Action.Break);
		Player.AddInputEventDelegate(Decelerate, UpdateLoopType.Update, InputActionEventType.ButtonUnpressed,
			RewiredConsts.Action.Accelerate);
		Player.AddInputEventDelegate(SetAim, UpdateLoopType.Update, InputActionEventType.Update,
			RewiredConsts.Action.Steer);
		yield return new WaitForSeconds(LapManager.Instance.start.length);
		maxSpeed = temp;
		minSpeed = temp2;
	}

	void OnDisable() {
		base.OnDisable();
		onLap -= OnFinish;
	}	

	void Accelerate(InputActionEventData data) {
		if (!Player.GetButton(RewiredConsts.Action.Break))
		{
			currentSpeed += accelerationDelta;
			currentSpeed = Mathf.Clamp(currentSpeed, minSpeed, maxSpeed);
		}
	}

	void Break(InputActionEventData data) {
		currentSpeed -= accelerationDelta*3;
		currentSpeed = Mathf.Clamp(currentSpeed, minSpeed, maxSpeed);
	}

	void Decelerate(InputActionEventData data) {
		if (!Player.GetButton(RewiredConsts.Action.Break)) {
			currentSpeed -= accelerationDelta * 2;
			currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed);
		}
	}

	private void Update() {
		base.Update();
		rb.position += transform.forward * currentSpeed * Time.deltaTime;
	}

	void SetAim(InputActionEventData data) {
		var angolo = Mathf.Asin(Player.GetAxis(RewiredConsts.Action.Steer));
		angolo = Mathf.Rad2Deg * angolo;
		var raycastDir = Quaternion.Euler(0, angolo, 0) * transform.forward;
		transform.forward = Vector3.Lerp(transform.forward, raycastDir, steeringspeed * Time.deltaTime);
	}

	private void OnCollisionEnter(Collision collision) {
		base.OnCollisionEnter(collision);
		if (collision.gameObject.CompareTag("Muri")) {
			Player.SetVibration(0,currentSpeed/maxSpeed,0.5f);
			Player.SetVibration(1,currentSpeed/maxSpeed,0.5f);
		}
	}

	private void OnFinish() {
		if (lap==LapManager.Instance.maxLap) {
			LapManager.Instance.sfx.PlayOneShot(LapManager.Instance.congratulation);

		}
	}

}