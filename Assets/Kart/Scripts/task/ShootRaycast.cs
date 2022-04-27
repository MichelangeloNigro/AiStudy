using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class ShootRaycast : Action {
	public SharedGameObject targetGameObject;
	public int NumberOfRaycast;
	public float maxRayDistance;
	public int maxRange;
	private LayerMask mask;
	private Transform transformSelf;
	private Vector3 sum;
	public SharedVector3 storeResult;
	public SharedVector3 sumNotNormalized;
	public override void OnStart() {
		 transformSelf = GetDefaultGameObject(targetGameObject.Value).transform;
		mask = LayerMask.GetMask("Muri");
		sum = Vector3.zero;

	}

	public override TaskStatus OnUpdate()
	{
		float deltaAngles = (float)maxRange / (NumberOfRaycast - 1);
		Debug.Log(transform.rotation.eulerAngles.x);
		var raycastDir = Quaternion.Euler(transform.rotation.eulerAngles.x, -maxRange/2f, transform.rotation.eulerAngles.z) * transformSelf.forward;
		for (int i = 0; i < NumberOfRaycast; i++) { 
			var raycasthit = new RaycastHit();
			var ray=new Ray(transformSelf.position, raycastDir);
			if (Physics.Raycast(ray,out raycasthit, maxRayDistance, mask)) {
				sum += (raycastDir * raycasthit.distance);
				Debug.DrawRay(transformSelf.position,raycastDir*raycasthit.distance,Color.red);
			}
			else {
				sum +=(raycastDir * maxRayDistance);
				Debug.DrawRay(transformSelf.position,raycastDir*maxRayDistance,Color.green);
			}
			raycastDir = Quaternion.Euler(0, deltaAngles, 0) * raycastDir;
		}
		Debug.DrawRay(transformSelf.position,sum,Color.black);
		storeResult.SetValue(sum.normalized);
		sumNotNormalized.SetValue(sum);
		return TaskStatus.Success;
	}
}