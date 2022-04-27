using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using Rewired;

public class CallStopBreak : Action
{
	private MacchininaBase macchininaBase;
	public override void OnStart() {
		macchininaBase=transform.GetComponent<MacchininaBase>();
	}

	public override TaskStatus OnUpdate()
	{
		macchininaBase.stopBreaking(new InputActionEventData());
		return TaskStatus.Success;
	}
}