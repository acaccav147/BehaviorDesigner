using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace MyExample
{
	[TaskCategory("MyExample/DynamicLoad")]
	[TaskDescription("Get defence target")]
	public class GetTarget : Action
	{
		private GameObject obj;
		public override void OnStart()
		{
			obj = GameObject.Find("Defence");
			GlobalVariables.Instance.SetVariable("targetObj", (SharedGameObject)obj);
		}

		public override TaskStatus OnUpdate()
		{
			if(obj)
				return TaskStatus.Success;

			return TaskStatus.Failure;
		}
	}
}