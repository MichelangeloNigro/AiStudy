using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class CheckDistanceToWall : Action {
	public SharedVector3 dir;
	public SharedFloat distance;
	private Ray ray;
	private RaycastHit hit;
	public override void OnStart() {
		ray = new Ray(transform.position, dir.Value);
	}

	public override TaskStatus OnUpdate() {
		Physics.Raycast(ray,out hit,Mathf.Infinity,LayerMask.GetMask("Muri"));
		distance.SetValue(hit.distance);
		return TaskStatus.Success;
	}
}