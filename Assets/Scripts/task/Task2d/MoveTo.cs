using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class MoveTo : Action
{
	public SharedGameObject TargetToMove;
	public SharedFloat vel;
	public SharedInt direction;
	public override void OnStart()
	{
		
	}

	public override TaskStatus OnUpdate()
	{
		Vector3 dir = TargetToMove.Value.transform.position-transform.position;
		transform.position += dir.normalized * Time.deltaTime*vel.Value*direction.Value;
		//transform.position = Vector3.MoveTowards(transform.position, TargetToMove.Value.transform.position, 0.2f*Time.deltaTime);
		transform.LookAt(TargetToMove.Value.transform, Vector3.up);
		return TaskStatus.Success;
	}
}