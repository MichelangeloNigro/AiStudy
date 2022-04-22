using System;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using Action = BehaviorDesigner.Runtime.Tasks.Action;

public class CallFindClosest : Action
{
	public toFind tofind;
	public SharedTransform target;
	public SharedFloat distance;
	
	public override void OnStart()
	{
		
		
	}

	public override TaskStatus OnUpdate()
	{
		switch (tofind)
		{
			case toFind.Dot:
				Tuple<Transform,float> temp=Manager.Instance.GetClosestDotToPacman();
				if (temp==null)
				{
					return TaskStatus.Failure;
				}
				target.Value = temp.Item1;
				distance.Value = temp.Item2;
				break;
			case toFind.Ghost:
				Tuple<Transform,float> temp2=Manager.Instance.GetClosestGhostToPacman();
				if (temp2==null)
				{
					return TaskStatus.Failure;
				}
				target.Value = temp2.Item1;
				distance.Value = temp2.Item2;
				break;
			case toFind.Antighost:
				Tuple<Transform,float> temp3=Manager.Instance.GetClosestEmpowerToPacman();
				if (temp3==null)
				{
					return TaskStatus.Failure;
				}
				target.Value = temp3.Item1;
				distance.Value = temp3.Item2;
				break;
			case toFind.Pacman:
				Tuple<Transform,float> temp4=Manager.Instance.GetClosestPacman(transform.position);
				if (temp4==null)
				{
					return TaskStatus.Failure;
				}
				target.Value = temp4.Item1;
				distance.Value = temp4.Item2;
				break;
			default:
				throw new ArgumentOutOfRangeException();
		}
		return TaskStatus.Success;
	}

	public enum toFind
	{
		Dot,
		Ghost,
		Antighost,
		Pacman
	}
}