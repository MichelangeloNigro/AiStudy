using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class GetFoodInSight : Action
{
	public SharedBool foodInSight;
	public SharedGameObject lattuga;
	public override void OnStart()
	{
		
	}

	public override TaskStatus OnUpdate() {
		lattuga.Value = transform.GetComponent<Ant>().lettuce;
		foodInSight.Value=transform.GetComponent<Ant>().foodDetected;
		return TaskStatus.Success;
	}
}