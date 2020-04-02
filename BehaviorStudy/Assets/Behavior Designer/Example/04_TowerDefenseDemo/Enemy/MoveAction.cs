using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace MyExample
{
	[TaskCategory("MyExample/DynamicLoad")]
	[TaskDescription("enemy move")]
	public class MoveAction : Action
	{
		public SharedGameObject target;
		private float speed = 2.0f;
		private float minDistance = 0.3f;
		public override void OnStart()
		{
			target = (GlobalVariables.Instance.GetVariable("targetObj") as SharedGameObject);
		}

		public override TaskStatus OnUpdate()
		{
			if(target.Value == null)
				return TaskStatus.Failure;

			this.transform.position = Vector3.MoveTowards(this.transform.position, target.Value.transform.position, Time.deltaTime * speed);
			if(Vector3.Distance(this.transform.position, target.Value.transform.position) <= minDistance)
			{
				var sp = target.Value.transform.GetComponent<SoldierProxy>();
				sp.OnDamage(10);
				Debug.LogError("炸掉hp 10, remaing: " + sp.Hp);
				GameObject.Destroy(this.gameObject);
				return TaskStatus.Success;
			}

			return TaskStatus.Running;
		}
	}

}