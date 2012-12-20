using UnityEngine;
using System.Collections;

public class DoHousework : State<MinersWife> 
{
	#region Singleton
	private static DoHousework _instance = null;
	public static DoHousework Instance 
	{
		get { return _instance ?? (_instance = new DoHousework()); }
	}
	#endregion
	
	#region State Members

	public override void Enter(MinersWife wife) { }

	public override void Execute(MinersWife wife)
	{
		switch(Mathf.RoundToInt(4*Random.value-0.5f))
		{
		case 0:
			wife.Speak("Moppin' the floor");
			break;
		case 1:
			wife.Speak("Washin' the dishes");
			break;
		case 2:
			wife.Speak("Makin' the bed");
			break;
		case 3:
			wife.Speak("Drinkin' cawfee");
			break;
		}
	}

	public override void Exit(MinersWife wife) { }
	
	#endregion
}
