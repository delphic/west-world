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
		if(miner.barTender != null && !miner.WaitingForDrink && miner.Thirsty)
		{
			miner.Speak(string.Format("Hey ya {0}, ahm hankin' for a drink!", miner.barTender));
			miner.OrderDrink();
		}
		else if (miner.barTender == null && miner.Thirsty)
		{
			// No Bar Tender apparent help yourself! 
			miner.BuyAndDrinkWhisky();
			miner.Speak("That's mighty fine sippin' liquer");
			miner.StateMachine.ChangeState(EnterMineAndDigForNugget.Instance);			
		}
	}

	public override void Exit(Miner miner)
	{
		miner.Speak("Leaving the saloon, feelin' good");
	}
	
	public override void OnMessage(Miner miner, WestWorldMessage message)
	{
		base.OnMessage(miner, message);
		if(message.Equals(WestWorldMessage.ServeDrink)) 
		{
			miner.DrinkWhisky();
			miner.Speak("That's mighty fine sippin' liquer");
			miner.StateMachine.ChangeState(EnterMineAndDigForNugget.Instance);
		}
	}
	
	#endregion
}
