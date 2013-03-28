public class ServeDrink : StateSingleton<ServeDrink, BarTender>
{
	#region State Members
	
	public override void Enter(BarTender bartender) { }

	public override void Execute(BarTender bartender)
	{
		bartender.Speak(string.Format("Here ya go {0}", bartender.patron.Name));
		bartender.patron.DispatchMessage(WestWorldMessage.ServeDrink);
		bartender.ServeDrink();
		bartender.StateMachine.RevertToPreviousState();
	}

	public override void Exit(BarTender bartender) { }
	
	#endregion
}
