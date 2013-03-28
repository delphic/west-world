public class VisitBathroom : StateSingleton<VisitBathroom, MinersWife> 
{
	#region State Members

	public override void Enter(MinersWife wife) 
	{
		wife.Speak("Walkin' to the can. Need to powda mah pretty li'lle nose");
	}

	public override void Execute(MinersWife wife)
	{
		wife.Speak("Ahhhhhh! Sweet relief!");
		wife.StateMachine.RevertToPreviousState();
	}

	public override void Exit(MinersWife wife) 
	{ 
		wife.Speak("Leavin' the Jon");
	}
	
	#endregion
}
