using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace MyExample
{
	[TaskCategory("MyExample/SharedVariable")]
    [TaskDescription("get sharedVariable")]
	public class GetVariableAction : Action
	{
		public BehaviorTree bt;

		public override void OnStart()
		{
			string str = (bt.GetVariable("tempVariable") as SharedString).Value;
			Debug.LogError("get a variable is :" + str);

			SharedGameObject go = GlobalVariables.Instance.GetVariable("tempGlobalVar") as SharedGameObject;
			Debug.LogError("get a global variable : " + go.Value.name);
		}

		public override TaskStatus OnUpdate()
		{
			return TaskStatus.Success;
		}
	}
}