using System.Collections;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime.Tasks.Unity.UnityGameObject;

public class Shoot : Action {
	public SharedGameObject prefab;
	public SharedFloat vel;
	public SharedInt ammo;
	public override void OnStart() {
		var gameobject=GameObject.Instantiate(prefab.Value,transform.position,transform.rotation);
		gameobject.GetComponent<Rigidbody>().velocity = gameobject.transform.forward * vel.Value*Time.deltaTime;
		ammo.Value--;
	}

	public override TaskStatus OnUpdate()
	{
		return TaskStatus.Success;
	}

}