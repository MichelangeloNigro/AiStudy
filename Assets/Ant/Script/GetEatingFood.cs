using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class GetEatingFood : Action
{
	public SharedBool EatingFood;
	public override void OnStart()
	{
		
	}

	public override TaskStatus OnUpdate()
	{
		EatingFood.Value=transform.GetComponent<Ant>().eatingFood;
		return TaskStatus.Success;
	}
}