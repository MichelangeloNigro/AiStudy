using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class GetAntInSight : Action {
	public SharedBool antinSight;
	public SharedGameObject ant;
	public override void OnStart()
	{
		
	}

	public override TaskStatus OnUpdate() {
		antinSight.Value=transform.GetComponent<Spider>().antInSight;
		ant.Value=transform.GetComponent<Spider>().ant;
		return TaskStatus.Success;
	}
}