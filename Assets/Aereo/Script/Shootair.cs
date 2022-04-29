using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class Shootair : Action {
	public SharedGameObject bullet;
	public SharedFloat bulletVel;
	public SharedFloat delay;
	public SharedInt ammo;
	private float timeTemp;
	public override void OnStart()
	{
		
	}

	public override TaskStatus OnUpdate() {
		if (delay.Value<=timeTemp) {
			if (ammo.Value>0) {
				timeTemp = 0;
				var temp=UnityEngine.GameObject.Instantiate(bullet.Value,transform.position,transform.rotation);
				temp.GetComponent<Rigidbody>().velocity=transform.forward*bulletVel.Value*Time.deltaTime;
				Physics.IgnoreCollision(transform.GetComponent<Collider>(),temp.GetComponent<Collider>());
				ammo.Value--;
			}
		}
		timeTemp += Time.deltaTime;
		return TaskStatus.Success;
		
	}
}