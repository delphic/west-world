public class QuenchThirst : State<Miner> 
{
	#region Singleton
	private static QuenchThirst _instance = null;
	public static QuenchThirst Instance 
	{
		get { return _instance ?? (_instance = new QuenchThirst()); }
	}
	#endregion
	
	#region State Members
	
	public override void Enter(Miner miner)
	{
		if(!miner.Location.Equals(WestWorldLocation.Saloon))
		{
			miner.ChangeLocation(WestWorldLocation.Saloon);
			miner.Speak("Boy, ah sure is thusty! Walking to the saloon");
		}
	}

	public override void Execute(Miner miner)
	{
		if(miner.Thirsty)
		{
			miner.BuyAndDrinkAWhisky();
			miner.Speak("That's mighty fine sippin' liquer");
			miner.StateMachine.ChangeState(EnterMineAndDigForNugget.Instance);
		}
	}

	public override void Exit(Miner miner)
	{
		miner.Speak("Leaving the saloon, feelin' good");
	}
	
	#endregion
}
