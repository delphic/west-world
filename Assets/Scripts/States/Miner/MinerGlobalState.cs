public class MinerGlobalState : StateSingleton<MinerGlobalState, Miner> 
{	
	#region State Members

	public override void Enter(Miner miner) { }

	public override void Execute(Miner miner)
	{
		miner.IncreaseThirst();
	}

	public override void Exit(Miner miner) { }
	
	#endregion
}
