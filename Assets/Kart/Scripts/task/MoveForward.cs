using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class MoveForward : Action
{
	public SharedGameObject targetGameObject;
	private Rigidbody rb;
	public SharedFloat currentSpeed;
	
	public override void OnStart()
	{
		rb = GetDefaultGameObject(targetGameObject.Value).GetComponent<Rigidbody>();
	}

	public override TaskStatus OnUpdate() {
		rb.position += transform.forward * currentSpeed.Value*Time.deltaTime;
		return TaskStatus.Success;
	}
}