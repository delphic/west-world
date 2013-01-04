using System.Collections.Generic;

public class BarTender : Agent<BarTender>
{
	#region Declarations
	
	public string barTenderName = "Joe the Barkeep";
	public Miner patron;
	
	private int _whiskeyShotsLeftInBarrel = 2; 
	
	#endregion
	
	#region MonoBehaviour Members
	
	new void Start()
	{
		base.Start();
		this._stateMachine = new FiniteStateMachine<BarTender>(this);
		this._stateMachine.SetCurrentState(TendBar.Instance);
		this._stateMachine.SetGlobalState(BarTenderGlobal.Instance);	
	}
	
	#endregion
	
	#region Public Accessors
	
	public string Name 
	{ 
		get { return this.barTenderName; } 
	}
	
	public bool WhiskeyBarrelEmpty
	{
		get { return !(this._whiskeyShotsLeftInBarrel > 0); }
	}
	
	#endregion
	
	#region Public Methods
	
	public void SetNewWhiskeyBarrel()
	{
		this._whiskeyShotsLeftInBarrel = 5;
	}
	
	public void ServeDrink()
	{
		this._whiskeyShotsLeftInBarrel--;
	}
	
	public void Speak(string message)
	{
		this._display.AddItem(this.Name, message);
	}
	
	#endregion
}
