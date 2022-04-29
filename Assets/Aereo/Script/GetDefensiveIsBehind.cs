using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class GetDefensiveIsBehind : Action
{
	public SharedBool hasBehind;
	public override void OnStart()
	{
		
	}

	public override TaskStatus OnUpdate()
	{
		hasBehind.Value=transform.gameObject.GetComponent<Defensive>().hasSomeoneBehind;
		return TaskStatus.Success;
	}
}