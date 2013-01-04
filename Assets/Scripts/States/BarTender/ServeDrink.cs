public class ServeDrink : State<BarTender>
{
	#region Singleton
	private static ServeDrink _instance = null;
	public static ServeDrink Instance 
	{
		get { return _instance ?? (_instance = new ServeDrink()); }
	}
	#endregion

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
