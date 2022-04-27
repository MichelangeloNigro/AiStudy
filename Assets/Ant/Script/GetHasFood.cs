using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class GetHasFood : Action
{
	public SharedBool hasFood;
	public override void OnStart()
	{
		
	}

	public override TaskStatus OnUpdate()
	{
		hasFood.Value=transform.GetComponent<Ant>().carryingFood;
		return TaskStatus.Success;
	}
}