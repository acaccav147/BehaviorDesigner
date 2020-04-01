using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Water
{
	public class Main : MonoBehaviour
	{
		private int timer;

		private void cb()
		{
			Debug.LogError("i am cb");
		}
		// Start is called before the first frame update
		void Start()
		{
			timer = GameTimer.Instance.CreateGameTimer(1f, true, cb, true);
			Debug.LogError("timer : " + timer);
			// GameTimer.Instance.StartGameTimer(timer);
		}

		// Update is called once per frame
		void Update()
		{
			GameTimer.Instance.UpdateGameTimer();
		}
	}
}
