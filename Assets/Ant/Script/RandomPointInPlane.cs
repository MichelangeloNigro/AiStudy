using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class RandomPointInPlane : Action {
	public SharedGameObject plane;
	public SharedVector3 point;
	public override void OnStart()
	{
		
	}

	public override TaskStatus OnUpdate() {
		point.Value = new Vector3(Random.Range(plane.Value.GetComponent<MeshCollider>().bounds.min.x,plane.Value.GetComponent<MeshCollider>().bounds.min.x),transform.position.y,Random.Range(plane.Value.GetComponent<MeshCollider>().bounds.min.z,plane.Value.GetComponent<MeshCollider>().bounds.min.z));
		return TaskStatus.Success;
	}
}