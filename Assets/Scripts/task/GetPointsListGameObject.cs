using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using System.Collections.Generic;
using BehaviorDesigner.Runtime.Tasks.Unity.UnityTransform;

[TaskCategory("PointList")]
public class GetPointsListGameObject : Action
{
	[SerializeField] SharedTransformList _points = null;
	List<Transform> _pointsVal;
	[SerializeField] SharedInt _index = null;
	int _indexVal;
	[SerializeField] SharedGameObject _storedResult = null;

	public override void OnStart()
	{
		_pointsVal = _points.Value;
		_indexVal = _index.Value;
	}

	public override TaskStatus OnUpdate()
	{
		if(_indexVal >= _pointsVal.Count)
        {
			_index.SetValue(0);
			_indexVal = _index.Value;
		}
		_storedResult.SetValue(_pointsVal[_indexVal].gameObject);

		return TaskStatus.Success;
	}
}