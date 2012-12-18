public class MinersWifeGlobal : State<MinersWife> 
{
	#region Singleton
	private static MinersWifeGlobal _instance = null;
	public static MinersWifeGlobal Instance 
	{
		get { return _instance ?? (_instance = new MinersWifeGlobal()); }
	}
	#endregion
	
	#region State Members

	public override void Enter(MinersWife wife) { }

	public override void Execute(MinersWife wife)
	{
		if(UnityEngine.Random.value < 0.1f)
		{
			wife.StateMachine.ChangeState(VisitBathroom.Instance);
		}
	}

	public override void Exit(MinersWife wife) { }
	
	#endregion
}
