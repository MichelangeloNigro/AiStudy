using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class GetTarget : Action
{
	public SharedGameObject target;
	public override void OnStart()
	{
		
	}

	public override TaskStatus OnUpdate()
	{
		
		target.Value=transform.GetComponent<aereo>().target.gameObject;
		return TaskStatus.Success;
	}
}