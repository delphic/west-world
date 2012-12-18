using UnityEngine;

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
}
