using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class MoveForward : Action
{
	public SharedGameObject targetGameObject;
	private Transform transformSelf;
	public SharedFloat currentSpeed;
	
	public override void OnStart()
	{
		transformSelf = GetDefaultGameObject(targetGameObject.Value).transform;
	}

	public override TaskStatus OnUpdate() {
		transformSelf.position += transformSelf.forward * currentSpeed.Value;
		return TaskStatus.Success;
	}
}