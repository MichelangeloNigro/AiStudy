using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class RandomPointInPlane : Action {
	public SharedGameObject plane;
	public SharedVector3 point;
	private float timePassed;
	public SharedFloat timeToWait;
	public override void OnStart()
	{
		
	}

	public override TaskStatus OnUpdate() {
		timePassed += Time.deltaTime;
		if (timePassed>=timeToWait.Value) {
			timePassed = 0;
			point.Value = new Vector3(Random.Range(plane.Value.GetComponent<MeshCollider>().bounds.min.x,plane.Value.GetComponent<MeshCollider>().bounds.max.x),transform.position.y,Random.Range(plane.Value.GetComponent<MeshCollider>().bounds.min.z,plane.Value.GetComponent<MeshCollider>().bounds.max.z));
		}
		return TaskStatus.Success;
	}
}