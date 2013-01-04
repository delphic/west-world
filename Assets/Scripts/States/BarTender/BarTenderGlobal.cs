public class BarTenderGlobal : State<BarTender> 
{
	#region Singleton
	private static BarTenderGlobal _instance = null;
	public static BarTenderGlobal Instance 
	{
		get { return _instance ?? (_instance = new BarTenderGlobal()); }
	}
	#endregion

	#region State Members
	
	public override void Enter(BarTender bartender) { }

	public override void Execute(BarTender bartender) { }

	public override void Exit(BarTender bartender) { }
	
	public override void OnMessage(BarTender bartender, WestWorldMessage message)
	{
		base.OnMessage(bartender, message);
		if(message.Equals(WestWorldMessage.NeedDrink))
		{
			bartender.StateMachine.ChangeState(ServeDrink.Instance);
		}
	}
	
	#endregion
}
