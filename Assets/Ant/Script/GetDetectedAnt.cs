using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class GetDetectedAnt : Action {
	public SharedBool isDetected;
	public SharedGameObject spider;
	public override void OnStart()
	{
		
	}

	public override TaskStatus OnUpdate() {
		spider.Value = transform.GetComponent<Ant>().spider;
		isDetected.Value=transform.GetComponent<Ant>().isDetected;
		return TaskStatus.Success;
	}
}