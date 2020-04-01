using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Water
{
	public class GameTimer
	{
		private static GameTimer instance;
		public static GameTimer Instance
		{
			get{
				if(instance == null)
					instance = new GameTimer();

				return instance;
			}
		}

		public GameTimer(){}

		private static int staticIndex;
		public bool pause;

		private LinkedList<GameTimerItem> items = new LinkedList<GameTimerItem>();
		private Dictionary<int , GameTimerItem> hashIds = new Dictionary<int, GameTimerItem>();
		private List<GameTimerItem> addItems = new List<GameTimerItem>();

		public int CreateGameTimer(float interval_, bool isLoop_, D_Void_VOid cb_, bool autoStart_ = false)
		{
			GameTimerItem item = new GameTimerItem(++staticIndex, interval_, isLoop_, cb_);
			addItems.Add(item);
			hashIds.Add(item.index, item);

			if(autoStart_)
				item.enable = true;

			return item.index;
		}

		public void StartGameTimer(int index)
		{
			GameTimerItem item = hashIds[index];
			item.enable = true;
		}

		public void Pause(int index)
		{
			GameTimerItem item = hashIds[index];
			item.enable = false;
		}

		public void Stop(int index)
		{
			GameTimerItem item = hashIds[index];
			item.enable = false;
			item.delete = true;
		}

		public void UpdateGameTimer()
		{
			if(pause)
				return;

			for(int i = 0; i < addItems.Count; i++)
			{
				items.AddLast(addItems[i]);
			}
			addItems.Clear();

			LinkedListNode<GameTimerItem> cur, next = items.First;
			while(next != null)
			{
				cur = next;
				next = cur.Next;

				GameTimerItem item = cur.Value;
				if(item.delete)
				{
					items.Remove(cur);
					continue;
				}

				if(!item.enable)
					continue;

				if(item.Check(Time.deltaTime))
				{
					item.Invoke();
					if(!item.isLoop)
					{
						items.Remove(cur);
					}
				}
			}
		}

	}


	public class GameTimerItem
	{
		public int index;
		public float interval;
		public bool enable;
		public bool delete;
		public bool isLoop;
		public D_Void_VOid cb;
		private float lifeTime;
		public GameTimerItem(int index_, float interval_, bool isLoop_, D_Void_VOid cb_)
		{
			this.index = index_;
			this.interval = interval_;
			this.isLoop = isLoop_;
			this.cb = cb_;
		}

		public bool Check(float deltaTime)
		{
			lifeTime += deltaTime;
			return lifeTime >= interval;
		}

		public void Invoke()
		{
			if(cb != null)
				cb();
			lifeTime = 0;
		}

	}
}
