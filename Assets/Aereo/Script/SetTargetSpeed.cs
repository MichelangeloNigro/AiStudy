using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class SetTargetSpeed : Action
{
	public SharedFloat target;
	public SharedFloat current;
	public override void OnStart()
	{
		
	}

	public override TaskStatus OnUpdate()
	{
		target.Value = current.Value;
		return TaskStatus.Success;
	}
}