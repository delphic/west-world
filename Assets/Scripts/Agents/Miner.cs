public class Miner : Agent<Miner> 
{
	#region Declarations
	
	public string minerName = "Miner Bob";
	public MinersWife wife = null;
	public BarTender barTender = null;
	
	private const int COMFORT_LEVEL = 5;
	private const int MAX_NUGGETS = 3;
	private const int THIRST_LEVEL = 5;
	private const int TIREDNESS_THRESHOLD = 5;
	
	private WestWorldLocation _location = WestWorldLocation.Shack;
	private int _goldCarried = 0;
	private int _moneyInBank = 0;
	private int _thirst = 0;
	private int _fatigue = 0;
	private bool _waitingForDrink = false;
	
	#endregion
	
	#region MonoBehaviour Members
	
	new void Start () 
	{
		base.Start();
		this._stateMachine = new FiniteStateMachine<Miner>(this);
		this._stateMachine.SetCurrentState(GoHomeAndSleepUntilRested.Instance);
		this._stateMachine.SetGlobalState(MinerGlobalState.Instance);	
	}	
	
	#endregion
	
	#region Public Accessors
	
	public string Name 
	{ 
		get { return this.minerName; } 
	}
	
	public WestWorldLocation Location 
	{ 
		get { return this._location; } 
	}
	
	public bool PocketsFull
	{
		get { return (this._goldCarried >= MAX_NUGGETS); }
	}
	
	public bool Fatigued
	{
		get { return (this._fatigue > TIREDNESS_THRESHOLD); }
	}
	
	public bool Thirsty
	{
		get { return (this._thirst > THIRST_LEVEL); }
	}
	
	public bool WaitingForDrink 
	{
		get { return this._waitingForDrink; }
	}
	
	public bool ComfortablyWealthy
	{
		get { return (this._moneyInBank > COMFORT_LEVEL); }
	}
	
	public int GoldCarried
	{
		get { return this._goldCarried; }
	}
	
	public int Wealth
	{
		get { return this._moneyInBank; }
	}
	
	#endregion
	
	#region Public Methods
	
	public void Speak(string message)
	{
		this._display.AddItem(this.Name, message);
	}
	
	public void DepositGold()
	{
		this.AddToWealth(this._goldCarried);
		this._goldCarried = 0;
	}
	
	public void IncreaseThirst() 
	{
		this._thirst++;
	}
	
	public void IncreaseFatigue()
	{
		this._fatigue++;
	}
	
	public void DecreaseFatigue()
	{
		this._fatigue--;
	}
	
	public void ChangeLocation(WestWorldLocation newLocation) 
	{
		this._location = newLocation;
	}
	
	public void AddToGoldCarried(int numberOfGoldNuggets) 
	{
		this._goldCarried += numberOfGoldNuggets;
	}
	
	public void AddToWealth(int wealthIncrease)
	{
		this._moneyInBank += wealthIncrease;
	}
	
	public void BuyAndDrinkWhisky()
	{
		this._moneyInBank = -2;
		this._thirst = 0;
	}
	
	public void OrderDrink()
	{
		this._waitingForDrink = true;
		this.barTender.DispatchMessage(WestWorldMessage.NeedDrink);
		this._moneyInBank = -2;
	}
	
	public void DrinkWhisky()
	{
		this._waitingForDrink = false;
		this._thirst = 0; 
	}
	
	#endregion
}
