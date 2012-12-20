public class EatStew : State<Miner> 
{
	#region Singleton
	private static EatStew _instance = null;
	public static EatStew Instance 
	{
		get { return _instance ?? (_instance = new EatStew()); }
	}
	#endregion

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
