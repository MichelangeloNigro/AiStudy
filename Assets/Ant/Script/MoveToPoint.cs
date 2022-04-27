using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class MoveToPoint : Action
{
	public SharedVector3 TargetToMove;
	public SharedFloat vel;
	public SharedInt direction;
	public override void OnStart()
	{
		
	}

	public override TaskStatus OnUpdate()
	{
		Vector3 dir = (TargetToMove.Value-transform.position)*direction.Value;
		dir=Vector3.ProjectOnPlane(dir, Vector3.up);
		transform.position += dir.normalized * Time.deltaTime*vel.Value;
		//transform.position = Vector3.MoveTowards(transform.position, TargetToMove.Value.transform.position, 0.2f*Time.deltaTime);
		Quaternion toRotation = Quaternion.LookRotation(dir, transform.up);
		transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, vel.Value/2 * Time.deltaTime);
		return TaskStatus.Success;
	}
}