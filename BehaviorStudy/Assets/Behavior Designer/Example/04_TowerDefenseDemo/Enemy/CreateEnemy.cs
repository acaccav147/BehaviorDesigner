using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace MyExample
{
	[TaskCategory("MyExample/DynamicLoad")]
	public class CreateEnemy : Action
	{
		public SharedGameObject enemy;
		private GameObject obj;
		public override void OnStart()
		{
			obj = GameObject.Instantiate(enemy.Value);
			Vector3 pos = (this.transform.GetComponent<BehaviorTree>().GetVariable("BirthPos") as SharedVector3).Value;
			obj.transform.position = pos;
		}

		public override TaskStatus OnUpdate()
		{
			return obj ? TaskStatus.Success : TaskStatus.Failure;
		}
	}
}