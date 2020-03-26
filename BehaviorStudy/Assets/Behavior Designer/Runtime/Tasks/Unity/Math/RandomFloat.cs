using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Unity.Math
{
    [TaskCategory("Unity/Math")]
    [TaskDescription("Sets a random float value")]
    public class RandomFloat : Action
    {
        [Tooltip("The minimum amount")]
        public SharedFloat min;
        [Tooltip("The maximum amount")]
        public SharedFloat max;
        [Tooltip("Is the maximum value inclusive?")]
        public bool inclusive;
        [Tooltip("The variable to store the result")]
        public SharedFloat storeResult;

#region add new code
        public GameObject obj;
        public BehaviorTree bt;
        private float originY = 0;
		public override void OnStart()
		{
			SharedGameObject sobj = bt.GetVariable("pop_prefab") as SharedGameObject;
			obj = GameObject.Instantiate(sobj.Value);
            if(obj)
                originY = obj.transform.position.y;
		}
#endregion
        public override TaskStatus OnUpdate()
        {
            if (inclusive) {
                storeResult.Value = Random.Range(min.Value, max.Value);
            } else {
                storeResult.Value = Random.Range(min.Value, max.Value - 0.00001f);
            }
#region add new code
            if(obj)
            {
                obj.transform.position = Vector3.MoveTowards(obj.transform.position, new Vector3(obj.transform.position.x, obj.transform.position.y + storeResult.Value, obj.transform.position.z), 2 * Time.deltaTime);
                if(Mathf.Abs(obj.transform.position.y - originY) < 3)
                    return TaskStatus.Running;
                else
                {
                    GameObject.Destroy(obj);
                    return TaskStatus.Success;
                }
            }
            return TaskStatus.Failure;
#endregion
        }

        public override void OnReset()
        {
            min.Value = 0;
            max.Value = 0;
            inclusive = false;
            storeResult.Value = 0;
        }
    }
}