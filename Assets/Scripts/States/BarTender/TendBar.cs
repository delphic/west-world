using UnityEngine;

public class TendBar : State<BarTender> 
{
	#region Singleton
	private static TendBar _instance = null;
	public static TendBar Instance 
	{
		get { return _instance ?? (_instance = new TendBar()); }
	}
	#endregion

	#region State Members
	
	public override void Enter(BarTender bartender) { }

	public override void Execute(BarTender bartender)
	{
		if(bartender.WhiskeyBarrelEmpty)
		{
			bartender.StateMachine.ChangeState(HaulBarrel.Instance);
		}
		else
		{
			switch(Mathf.RoundToInt(5*Random.value-0.5f))
			{
			case 0:
				bartender.Speak("Wipin' the bar");
				break;
			case 1:
				bartender.Speak("Checkin' the stock");
				break;
			case 2:
				bartender.Speak("Whistlin' a tune");
				break;
			case 3:
				bartender.Speak("Taklin' to patrons");
				break;
			case 4:
				bartender.Speak("Thowin' out Barfly");
				break;
			}
		}
	}

	public override void Exit(BarTender bartender) { }
	
	#endregion
}
