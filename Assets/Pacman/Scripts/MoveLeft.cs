using System.Numerics;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class MoveLeft : Action {
	public SharedFloat vel;
	public SharedGameObject TargetToMove;
	public SharedFloat maxDistance;
	public SharedFloat minDistance;
	public SharedInt rand;
	public override void OnStart() {

		
	
	}

	public override TaskStatus OnUpdate()
	{
		Vector3 dir= (TargetToMove.Value.transform.position-transform.position)*-1;
		dir=Vector3.ProjectOnPlane(dir, Vector3.up);
		Quaternion toRotation = Quaternion.LookRotation(-TargetToMove.Value.transform.forward, transform.up);
		transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, vel.Value/2 * Time.deltaTime);
		Debug.Log(Vector3.Distance(transform.position, TargetToMove.Value.transform.position));
		if (Vector3.Distance(transform.position, TargetToMove.Value.transform.position) > maxDistance.Value) {
			return TaskStatus.Failure;
		}
		if (Vector3.Distance(transform.position, TargetToMove.Value.transform.position) < minDistance.Value) {
			return TaskStatus.Failure;
		}
		transform.position +=(Quaternion.Euler(transform.rotation.eulerAngles.x, rand.Value, transform.rotation.eulerAngles.z) * dir).normalized * Time.deltaTime*vel.Value;
		Debug.DrawRay(transform.position,(Quaternion.Euler(transform.rotation.eulerAngles.x, rand.Value, transform.rotation.eulerAngles.z) * dir),Color.black);
		return TaskStatus.Success;
	}
}