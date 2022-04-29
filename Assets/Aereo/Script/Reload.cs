using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class Reload : Action {
	public SharedInt ammo;
	public SharedInt maxAmmo;
	public override void OnStart()
	{
		
	}

	public override TaskStatus OnUpdate() {
		ammo.Value = maxAmmo.Value;
		return TaskStatus.Success;
	}
}