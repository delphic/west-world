using UnityEngine;
using System.Collections;

public abstract class Agent<T> : MonoBehaviour 
{
	#region Declarations
	
	protected const float TICK_TIME = 2.0f;
	
	protected FiniteStateMachine<T> _stateMachine;
	protected WestWorldDisplayer _display;
	
	private float _timeSinceLastTick = TICK_TIME;
	
	#endregion
	
	public FiniteStateMachine<T> StateMachine 
	{
		get { return this._stateMachine; }
	}
	
	#region MonoBehaviour Members
	
	protected void Start()
	{
		_display = WestWorldDisplayer.Instance;
	}
	
	void Update() 
	{
		_timeSinceLastTick += Time.deltaTime;
		if(_timeSinceLastTick > TICK_TIME)
		{
			_timeSinceLastTick = 0.0f;
			this._stateMachine.Update();
		}
	}
	
	#endregion
	
	#region Messsaging
	
	public void DispatchMessage(WestWorldMessage message) 
	{
		this.StateMachine.HandleMessage(message);
	}
	
	public void DelayedMessage(float delay, WestWorldMessage message)
	{
		StartCoroutine(DispatchMessageAfterDelay(delay, message));
	}
	
	IEnumerator DispatchMessageAfterDelay(float delay, WestWorldMessage message)
	{
		yield return new WaitForSeconds(delay);
		this.DispatchMessage(message);
	}
	
	#endregion
}
