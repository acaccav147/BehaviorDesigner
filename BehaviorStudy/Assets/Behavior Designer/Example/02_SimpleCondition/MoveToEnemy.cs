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
		public BehaviorTree bt;

		public override void OnStart()
		{
			
		}

		public override TaskStatus OnUpdate()
		{
			if(targetGo != null && originGo != null && Vector3.Distance(originGo.Value.transform.position, targetGo.Value.transform.position) > 0.2f)
			{
				originGo.Value.transform.position = Vector3.MoveTowards(originGo.Value.transform.position, targetGo.Value.transform.position, Time.deltaTime * 2);
				return TaskStatus.Running;
			}

			bt.SendEvent("Evt_MoveEnd");
			return TaskStatus.Success;
		}
	}
}