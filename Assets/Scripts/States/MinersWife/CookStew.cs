public class CookStew : StateSingleton<CookStew, MinersWife>
{
	#region State Members
	
	private const float COOKING_TIME = 4.0f;
	
	public override void Enter(MinersWife wife)
	{
		if(!wife.cooking)
		{
			wife.Speak("Puttin' the stew in the oven");
			wife.DelayedMessage(COOKING_TIME, WestWorldMessage.StewReady);
			wife.cooking = true;
		}
	}

	public override void Execute(MinersWife wife)
	{
		wife.Speak("Fussin' over food");
	}

	public override void Exit(MinersWife wife)
	{
		wife.Speak("Puttin' the stew on the table");	
	}
	
	#endregion
}
