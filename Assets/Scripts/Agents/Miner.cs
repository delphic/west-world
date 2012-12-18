using UnityEngine;

public class Miner : MonoBehaviour 
{
	#region Declarations
	
	public string minerName = "Miner Bob";
	
	private const int COMFORT_LEVEL = 5;
	private const int MAX_NUGGETS = 3;
	private const int THIRST_LEVEL = 5;
	private const int TIREDNESS_THRESHOLD = 5;
	private const float TICK_TIME = 5.0f;
	
	private WestWorldLocation _location = WestWorldLocation.Shack;
	private int _goldCarried = 0;
	private int _moneyInBank = 0;
	private int _thirst = 0;
	private int _fatigue = 0;
	
	private FiniteStateMachine<Miner> _stateMachine;
	private WestWorldDisplayer _display;
	
	private float _timeSinceLastTick = TICK_TIME;
	
	#endregion
	
	#region MonoBehaviour Members
	
	void Start () 
	{
		this._stateMachine = new FiniteStateMachine<Miner>(this);
		this._stateMachine.SetCurrentState(GoHomeAndSleepUntilRested.Instance);
		this._stateMachine.SetGlobalState(MinerGlobalState.Instance);	
		_display = WestWorldDisplayer.Instance;
	}
	
	void Update () 
	{
		_timeSinceLastTick += Time.deltaTime;
		if(_timeSinceLastTick > TICK_TIME)
		{
			_timeSinceLastTick = 0.0f;
			this._stateMachine.Update();
		}
	}
	
	#endregion
	
	#region Public Accessors
	
	public FiniteStateMachine<Miner> StateMachine 
	{
		get { return this._stateMachine; }
	}
	
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
		this._display.AddItem(string.Format("{0}: {1}", this.Name, message));
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
	
	public void BuyAndDrinkAWhisky()
	{
		this._thirst = 0; 
		this._moneyInBank -= 2;
	}
	
	#endregion
}