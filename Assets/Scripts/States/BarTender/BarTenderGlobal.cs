public class BarTenderGlobal : StateSingleton<BarTenderGlobal, BarTender> 
{
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
