using System;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using Action = BehaviorDesigner.Runtime.Tasks.Action;

public class RotateTowardPoint : Action
{
	public SharedVector3 dir;
	public SharedFloat vel;
	private float rotation;

	public override void OnStart()
	{
		
	}

	public override TaskStatus OnUpdate()
	{
		transform.forward = Vector3.Lerp(transform.forward, dir.Value.normalized, vel.Value * Time.deltaTime);
		if (AngleDir(transform.forward, dir.Value.normalized, Vector3.up) == 1) {
			transform.rotation = (Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, -90*MathF.Abs(rotation)));
		}
		else if (AngleDir(transform.forward, dir.Value.normalized,  Vector3.up) == -1) {
			transform.rotation = (Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 90*MathF.Abs(rotation)));
		}
		else {
			transform.rotation = (Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 1*MathF.Abs(rotation)));
		}
		return TaskStatus.Success;
	}
	public float AngleDir(Vector3 fwd, Vector3 targetDir, Vector3 up) {
		Vector3 perp = Vector3.Cross(fwd, targetDir);
		rotation = Vector3.Dot(perp, up);
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