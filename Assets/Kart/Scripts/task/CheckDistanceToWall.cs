using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class CheckDistanceToWall : Action {
	public SharedVector3 dir;
	public SharedFloat distance;
	private Ray ray;
	private RaycastHit hit;
	public override void OnStart() { }

	public override TaskStatus OnUpdate() {
		ray = new Ray(transform.position, dir.Value);
		Debug.DrawRay(transform.position,dir.Value*100,Color.blue);
		if (Physics.Raycast(ray, out hit, Mathf.Infinity, LayerMask.GetMask("Muri")))
		{
			Debug.Log(hit.collider.gameObject);
			distance.SetValue(hit.distance);
		}
		else
		{
			hit.distance = Mathf.Infinity;
		}
//		Debug.Log(hit.distance);
		return TaskStatus.Success;
	}
}