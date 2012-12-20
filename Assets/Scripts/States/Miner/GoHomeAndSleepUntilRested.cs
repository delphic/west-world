public class GoHomeAndSleepUntilRested : State<Miner> 
{
	#region Singleton
	private static GoHomeAndSleepUntilRested _instance = null;
	public static GoHomeAndSleepUntilRested Instance 
	{
		get { return _instance ?? (_instance = new GoHomeAndSleepUntilRested()); }
	}
	#endregion
	
	#region State Members
	
	public override void Enter(Miner miner)
	{
		if(!miner.Location.Equals(WestWorldLocation.Shack))
		{
			miner.Speak("Walkin' home");
			miner.ChangeLocation(WestWorldLocation.Shack);
			miner.wife.DispatchMessage(WestWorldMessage.HoneyImHome);
		}
	}

	public override void Execute(Miner miner)
	{
		// If miner is not fatiguted start to dig for nuggets again
		if(!miner.Fatigued)
		{
			miner.Speak("What a God darn fantastic nap! Time to find more gold");
			miner.StateMachine.ChangeState(EnterMineAndDigForNugget.Instance);
		}
		else
		{
			// sleep
			miner.DecreaseFatigue();
			miner.Speak("zZzZz...");
		}
	}

	public override void Exit(Miner miner)
	{
		miner.Speak("Leaving the house");
	}	
	
	public override void OnMessage (Miner agent, WestWorldMessage message)
	{
		base.OnMessage (agent, message);
		switch(message)
		{
		case WestWorldMessage.StewReady:
			agent.Speak("Okay hun, ahm a-comin'!");
			agent.StateMachine.ChangeState(EatStew.Instance);
			break;
		}
	}
	
	#endregion
}
