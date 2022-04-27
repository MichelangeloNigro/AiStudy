using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class ClampRotation : Action
{
	public SharedGameObject targetGameObject;
	private Transform transformSelf;

	public override void OnStart() {
		Debug.Log(transform.rotation.eulerAngles);
		transformSelf = GetDefaultGameObject(targetGameObject.Value).transform;
	}

	public override TaskStatus OnUpdate() {
		transformSelf.localRotation.eulerAngles.Set(0, Mathf.Clamp(transform.localRotation.eulerAngles.y,180,360), 0);
		return TaskStatus.Success;
	}
}