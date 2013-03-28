public class EatStew : StateSingleton<EatStew, Miner> 
{
	#region State Members
	
	public override void Enter(Miner miner)
	{
		miner.Speak(string.Format("Smells Reaaal good {0}!", miner.wife.Name));
	}

	public override void Execute(Miner miner)
	{
		miner.Speak("Tastes real good too!");
		miner.StateMachine.RevertToPreviousState();
	}

	public override void Exit(Miner miner)
	{
		miner.Speak("Thankya li'lle lady. Ah better get back to whatever ah wuz doin'");
	}
	
	#endregion
}
