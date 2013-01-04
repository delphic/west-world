public class HaulBarrel : State<BarTender>
{
	#region Singleton
	private static HaulBarrel _instance = null;
	public static HaulBarrel Instance 
	{
		get { return _instance ?? (_instance = new HaulBarrel()); }
	}
	#endregion

	#region State Members
	
	public override void Enter(BarTender bartender)
	{
		bartender.Speak("Dammit, out of whiskey!");
	}

	public override void Execute(BarTender bartender)
	{
		bartender.Speak("Haulin' a new barrel to the bar.");
		bartender.SetNewWhiskeyBarrel();
		bartender.StateMachine.ChangeState(TendBar.Instance);
	}

	public override void Exit(BarTender bartender) { }
	
	#endregion
}
