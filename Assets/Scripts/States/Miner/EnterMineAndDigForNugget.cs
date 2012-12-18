public class EnterMineAndDigForNugget : State<Miner> 
{
	#region Singleton
	private static EnterMineAndDigForNugget _instance = null;
	public static EnterMineAndDigForNugget Instance 
	{
		get { return _instance ?? (_instance = new EnterMineAndDigForNugget()); }
	}
	#endregion
	
	#region State Members
	
	public override void Enter(Miner miner)
	{
		if(!miner.Location.Equals(WestWorldLocation.GoldMine)) 
		{
			miner.Speak("Walkin' to the gold mine");
			miner.ChangeLocation(WestWorldLocation.GoldMine);
		}
	}

	public override void Execute(Miner miner)
	{
		// Miner digs for gold until his pockets are full of gold
		// If he gets thirsty during his digging he stops work and goes
		// to the saloon for a whisky (that well known thirst quencher)
		
		// Dig
		miner.AddToGoldCarried(1);
		miner.IncreaseFatigue();
		miner.Speak("Pickin' up a nugget");
	
		// Pockets are full, go and put gold in the bank
		if(miner.PocketsFull) 
		{
			miner.StateMachine.ChangeState(VisitBankAndDepositGold.Instance);
		}
		// If thirsty go and get a whiskey 
		else if (miner.Thirsty)
		{
			miner.StateMachine.ChangeState(QuenchThirst.Instance);
		}
	}

	public override void Exit(Miner miner)
	{
		miner.Speak("Ah'm leavin' the gold mine with mah pockets full o' sweet gold");
	}
	
	#endregion
}
