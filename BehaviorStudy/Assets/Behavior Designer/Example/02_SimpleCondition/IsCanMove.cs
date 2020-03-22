using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace MyExample
{
	[TaskCategory("MyExample/SimpleCondition")]
	[TaskDescription("check if the player can move")]
	public class IsCanMove : Conditional
	{
		public BehaviorTree bt;

		public override TaskStatus OnUpdate()
		{
			//add condition
			return (bt && (bt.GetVariable("g_target") as SharedGameObject).Value != null) ? TaskStatus.Success : TaskStatus.Failure; 
		}
	}
}