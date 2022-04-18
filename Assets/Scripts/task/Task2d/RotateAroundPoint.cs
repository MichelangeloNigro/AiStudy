using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class RotateAroundPoint : Action {
	public SharedFloat vel;
	public override void OnStart()
	{
		
	}

	public override TaskStatus OnUpdate() {
		transform.position += transform.right * vel.Value*Time.deltaTime;
		return TaskStatus.Success;
	}
}