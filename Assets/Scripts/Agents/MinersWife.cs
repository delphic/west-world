public class MinersWife : Agent<MinersWife> 
{
	#region Declarations
	
	public string wifeName = "Elsa";
	
	#endregion
	
	#region MonoBehaviour Members
	
	new void Start () 
	{
		base.Start();
		this._stateMachine = new FiniteStateMachine<MinersWife>(this);
		this._stateMachine.SetCurrentState(DoHousework.Instance);
		this._stateMachine.SetGlobalState(MinersWifeGlobal.Instance);	
	}	
	
	#endregion
	
	#region Public Accessors
	
	public string Name 
	{ 
		get { return this.wifeName; } 
	}
	
	#endregion
	
	#region Public Methods
	
	public void Speak(string message)
	{
		this._display.AddItem(this.Name, message);
	}
	
	#endregion
}
