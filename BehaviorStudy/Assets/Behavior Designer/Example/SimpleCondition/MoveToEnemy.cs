using UnityEngine;
using System.Collections.Generic;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace MyExample
{
	[TaskCategory("MyExample/SimpleCondition")]
	[TaskDescription("move towards the enemy")]
	public class MoveToEnemy : Action
	{
		public SharedGameObject targetGo;
		public SharedGameObject originGo;

		public override void OnStart()
		{
			
		}

		public override TaskStatus OnUpdate()
		{
			if(targetGo != null && originGo != null && Vector3.Distance(originGo.Value.transform.position, targetGo.Value.transform.position) > 0.2f)
			{
				originGo.Value.transform.position = Vector3.MoveTowards(originGo.Value.transform.position, targetGo.Value.transform.position, Time.deltaTime);
				return TaskStatus.Running;
			}

			return TaskStatus.Success;
		}
	}
}