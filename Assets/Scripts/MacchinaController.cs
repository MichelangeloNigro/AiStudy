using System;
using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class MacchinaController : MacchininaBase {
	public BehaviorTree tree;
	private SharedFloat currSpeedBehavior;

	// Start is called before the first frame update
	void Start() {
		base.Start();
		onLap += OnFinish;
		tree = GetComponent<BehaviorTree>();
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
	}

	private void Update() {
		currSpeedBehavior=tree.GetVariable("CurrentSpeed") as SharedFloat;
		currentSpeed = currSpeedBehavior.Value;
		base.Update();
	}
}