using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace MyExample
{
	[TaskCategory("MyExample/SimpleCondition")]
	[TaskDescription("find an enemy")]
	public class FindSingleEnemy : Action
	{
		public BehaviorTree bt;

		public override void OnStart()
		{
			
		}

		public override TaskStatus OnUpdate()
		{
			var gameObjects = GameObject.FindGameObjectsWithTag("Enemy");
			if(gameObjects.Length > 0)
			{
				SharedGameObject sgo = bt.GetVariable("g_target") as SharedGameObject;
				sgo.Value = gameObjects[Random.Range(0, gameObjects.Length - 1)];
				bt.SetVariable("g_target", sgo);
				return TaskStatus.Success;
			}
			return TaskStatus.Running;
		}
	}
}