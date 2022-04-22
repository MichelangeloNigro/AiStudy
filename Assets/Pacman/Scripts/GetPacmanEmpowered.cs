using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class GetPacmanEmpowered : Action
{
	public SharedBool Empowered;
	public override void OnStart()
	{
		
	}

	public override TaskStatus OnUpdate()
	{
		Empowered.Value = Object.FindObjectOfType<Pacman>().isEmpowered;
		return TaskStatus.Success;
	}
}