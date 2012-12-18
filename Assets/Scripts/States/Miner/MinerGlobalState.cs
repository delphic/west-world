public class MinerGlobalState : State<Miner> 
{
	#region Singleton
	private static MinerGlobalState _instance = null;
	public static MinerGlobalState Instance 
	{
		get { return _instance ?? (_instance = new MinerGlobalState()); }
	}
	#endregion
	
	#region State Members

	public override void Enter(Miner miner) { }

	public override void Execute(Miner miner)
	{
		miner.IncreaseThirst();
	}

	public override void Exit(Miner miner) { }
	
	#endregion
}
