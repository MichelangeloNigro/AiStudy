using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class SetTargetSpeed : Action
{
	public SharedFloat currentSpeed;
	public SharedFloat maxSpeed;
	public SharedFloat multiplier;
	public override void OnStart()
	{
		
	}

	public override TaskStatus OnUpdate() {
		currentSpeed.Value = maxSpeed.Value* multiplier.Value;
		return TaskStatus.Success;
	}
}