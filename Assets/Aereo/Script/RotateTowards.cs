using System;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using Action = BehaviorDesigner.Runtime.Tasks.Action;

public class RotateTowards : Action {
	public SharedGameObject target;
	public SharedFloat vel;
	private float rotation;

	public override void OnStart() { }

	public override TaskStatus OnUpdate() {
		Vector3 dir = target.Value.transform.position - transform.position;
		transform.forward = Vector3.Lerp(transform.forward, dir.normalized, vel.Value * Time.deltaTime);
		if (AngleDir(transform.forward, dir.normalized, Vector3.up) == 1) {
			transform.rotation = (Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, -90*MathF.Abs(rotation)));
		}
		else if (AngleDir(transform.forward, dir.normalized,  Vector3.up) == -1) {
			transform.rotation = (Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 90*MathF.Abs(rotation)));
		}
		else {
			transform.rotation = (Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 1*MathF.Abs(rotation)));
		}
		//transform.LookAt(target.Value.transform,Vector3.up);
		// transform.forward = dir.normalized;
		// transform.rotation=Quaternion.RotateTowards(transform.rotation,target.Value.transform.rotation,vel.Value);
		return TaskStatus.Success;
	}

	//returns -1 when to the left, 1 to the right, and 0 for forward/backward
	public float AngleDir(Vector3 fwd, Vector3 targetDir, Vector3 up) {
		Vector3 perp = Vector3.Cross(fwd, targetDir);
		rotation = Vector3.Dot(perp, up);
		Debug.Log(rotation);
		if (rotation > 0.1f) {
			return 1.0f;
		}
		else if (rotation < -0.1f) {
			return -1.0f;
		}
		else {
			return 0.0f;
		}
		
	}
}