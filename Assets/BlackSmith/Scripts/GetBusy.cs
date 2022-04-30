using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class GetBusy : Action {
	public SharedBool isBusy;

	public override void OnStart() { }

	public override TaskStatus OnUpdate() {
		isBusy.Value = transform.GetComponent<Worker>().isBusy;
		return TaskStatus.Success;
	}
}