using UnityEngine;

public abstract class State<T> where T : AgentBase 
{
	public abstract void Enter(T agent);
	public abstract void Execute(T agent);
	public abstract void Exit(T agent);
	public virtual void OnMessage(T agent, WestWorldMessage message) 
	{ 
		Debug.Log(string.Format(
			"Message '{0}' recieved at {1}",
			message.ToString(),
			Time.time));
	}
}
