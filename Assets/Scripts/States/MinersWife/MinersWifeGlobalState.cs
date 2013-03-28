public class MinersWifeGlobal : StateSingleton<MinersWifeGlobal, MinersWife> 
{
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
	
	public override void OnMessage(MinersWife wife, WestWorldMessage message)
	{
		base.OnMessage(wife, message);
		switch(message)
		{
		case WestWorldMessage.HoneyImHome:
			wife.Speak("Hi honey. Let me make you some of mah fine country stew");
			wife.StateMachine.ChangeState(CookStew.Instance);
			break;
		case WestWorldMessage.StewReady:
			wife.Speak("Stew ready! Let's eat");
			wife.husband.DispatchMessage(WestWorldMessage.StewReady);
			wife.cooking = false;
			wife.StateMachine.ChangeState(DoHousework.Instance);
			break;
		}
	}
	
	#endregion
}
