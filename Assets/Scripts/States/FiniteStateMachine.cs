public class FiniteStateMachine<T>
{
	private T _agent;
	private State<T> _globalState = null;
	private State<T> _currentState = null;
	private State<T> _previousState = null;
	
	public FiniteStateMachine(T agent) 
	{
		this._agent = agent;
	}
	
	public void SetGlobalState(State<T> globalState)
	{
		this._globalState = globalState;
	}
	
	public void SetCurrentState(State<T> state)
	{
		this._previousState = this._currentState;
		this._currentState = state;
	}
	
	public void ChangeState(State<T> newState)
	{
		this.SetCurrentState(newState);
		this._previousState.Exit(this._agent);
		this._currentState.Enter(this._agent);	
	}
	
	public void Update()
	{
		if (this._globalState != null) 
		{
			this._globalState.Execute(this._agent);
		}
		if (this._currentState != null)
		{
			this._currentState.Execute(this._agent);
		}
	}
	
	public void RevertToPreviousState()
	{
		this.ChangeState(this._previousState);
	}
	
	public void HandleMessage(WestWorldMessage message)
	{
		if (this._currentState != null)
		{
			this._currentState.OnMessage(_agent, message);
		}
		if (this._globalState != null)
		{
			this._globalState.OnMessage(_agent, message);
		}
	}
}
