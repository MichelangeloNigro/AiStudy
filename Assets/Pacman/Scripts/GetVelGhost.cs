using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class GetVelGhost : Action {
	public SharedFloat vel;
	public override void OnStart()
	{
		
	}

	public override TaskStatus OnUpdate() {
		vel.Value=transform.gameObject.GetComponent<Ghost>().vel;
		return TaskStatus.Success;
	}
}