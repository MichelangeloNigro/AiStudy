using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class Dodge : Action
{
	public SharedVector3 point;
	public SharedVector3 dir;
//Tipo corutine random, muove a destra sinistra su e giu
	public override void OnStart()
	{
		
	}

	public override TaskStatus OnUpdate()
	{
		UnityEngine.Transform avanti = transform.GetComponent<Defensive>().avanti;
		point.Value=avanti.position+(Random.insideUnitSphere*3000);
		dir.Value = point.Value - transform.position;
		return TaskStatus.Success;
	}
}