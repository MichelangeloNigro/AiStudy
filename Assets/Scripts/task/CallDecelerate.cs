using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using Rewired;

public class CallDecelerate : Action
{
	private MacchininaBase macchininaBase;
	public override void OnStart() {
		macchininaBase=transform.GetComponent<MacchininaBase>();
	}

	public override TaskStatus OnUpdate()
	{
		macchininaBase.Decelerate(new InputActionEventData());
		return TaskStatus.Success;
	}
}