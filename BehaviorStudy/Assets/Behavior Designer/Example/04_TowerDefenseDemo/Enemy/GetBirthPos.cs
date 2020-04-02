using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;

namespace MyExample
{
	[TaskCategory("MyExample/DynamicLoad")]
	public class GetBirthPos : Action
	{
		public SharedGameObjectList births;
		public override void OnStart()
		{
			// List<GameObject> birthObjs = births.Value;
			Vector2 vec = Random.insideUnitCircle * 10;
			Vector2 p = vec.normalized * (10 + vec.magnitude);
			Vector3 pos = new Vector3(p.x, 1, p.y);
			this.transform.GetComponent<BehaviorTree>().SetVariable("BirthPos", (SharedVector3)pos);
		}

		public override TaskStatus OnUpdate()
		{
			return TaskStatus.Success;
		}
	}
}