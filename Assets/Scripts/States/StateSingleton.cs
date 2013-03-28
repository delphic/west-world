using UnityEngine;
using System.Collections;

public abstract class StateSingleton<TState, TAgent> : State<TAgent> where TAgent : AgentBase where TState : new()
{	
	private static TState _instance = default(TState);
	public static TState Instance 
	{
		get  { return (!ReferenceEquals(_instance, default(TState))) ?  _instance : (_instance = new TState()); }
	}

}
