using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace MyExample
{
	[TaskCategory("MyExample/SimpleCondition")]
	[TaskDescription("reset a behaviortree")]
	public class ResetBT : Action
	{
		public BehaviorTree bt;
		public override void OnStart()
		{
			bt.EnableBehavior();
		}

		public override TaskStatus OnUpdate()
		{
			return TaskStatus.Success;
		}
	}
}