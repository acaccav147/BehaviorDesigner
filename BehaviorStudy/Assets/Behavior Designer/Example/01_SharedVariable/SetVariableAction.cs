using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace MyExample
{
	[TaskCategory("MyExample/SharedVariable")]
    [TaskDescription("set sharedVariable")]
	public class SetVariableAction : Action
	{
		public BehaviorTree bt;
		public SharedString oriStr;
		public SharedGameObject oriGo;

		public override void OnStart()
		{
			oriStr.Value = "i am a temp var";
			//Set a local variable with scope as the behavior tree
			bt.SetVariable("tempVariable", oriStr);

			//Set a global variable with a scope of all behavior trees
			GlobalVariables.Instance.SetVariable("tempGlobalVar", oriGo);
		}

		public override TaskStatus OnUpdate()
		{
			return TaskStatus.Success;
		}
	}
}