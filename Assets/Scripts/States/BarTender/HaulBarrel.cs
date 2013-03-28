public class HaulBarrel : StateSingleton<HaulBarrel, BarTender>
{
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
