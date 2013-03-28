public class VisitBankAndDepositGold : StateSingleton<VisitBankAndDepositGold, Miner> 
{	
	#region State Members
	
	public override void Enter(Miner miner)
	{
		if(!miner.Location.Equals(WestWorldLocation.Bank))
		{
			miner.Speak("Goin' to the bank. Yes siree");
			miner.ChangeLocation(WestWorldLocation.Bank);
		}
	}

	public override void Execute(Miner miner)
	{
		// Deposit Gold
		miner.DepositGold();
		miner.Speak(string.Format(
			"Depositing gold. Total savings now: {0}",
			miner.Wealth));
		
		// Wealthy enough to have a well earned rest?
		if(miner.ComfortablyWealthy)
		{
			miner.Speak("WooHoo! Rich enough for now. Back home to mah li'lle lady");
			miner.StateMachine.ChangeState(GoHomeAndSleepUntilRested.Instance);
		}
		// Otherwise get more gold
		else
		{
			miner.StateMachine.ChangeState(EnterMineAndDigForNugget.Instance);
		}
	}

	public override void Exit(Miner miner)
	{
		miner.Speak("Leavin' the bank");
	}	
	
	#endregion
}
