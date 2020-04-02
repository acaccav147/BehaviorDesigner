using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

namespace MyExample
{
	[TaskCategory("MyExample/DynamicLoad")]
	[TaskDescription("on battle end conditional")]
	public class OnBattleEnd : Conditional
	{
		private SoldierProxy sp;
		public override void OnStart()
		{
			GameObject target = (GlobalVariables.Instance.GetVariable("targetObj") as SharedGameObject).Value;
			sp = target.transform.GetComponent<SoldierProxy>();
		}
		public override TaskStatus OnUpdate()
		{
			if(sp == null || sp.Hp <= 0)
			{
				Debug.LogError("战斗结束");
				this.transform.GetComponent<BehaviorTree>().DisableBehavior();
				return TaskStatus.Success;
			}
			return TaskStatus.Running;
		}
	}
}