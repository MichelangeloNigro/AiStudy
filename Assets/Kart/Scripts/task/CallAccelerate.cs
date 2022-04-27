using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using Rewired;

public class CallAccelerate : Action {
	private MacchininaBase macchininaBase;
	public override void OnStart() {
	macchininaBase=transform.GetComponent<MacchininaBase>();
	}

	public override TaskStatus OnUpdate()
	{
		macchininaBase.Accelerate(new InputActionEventData());
		return TaskStatus.Success;
	}
}