using UnityEngine;
using System.Collections.Generic;

public class WestWorldDisplayer : MonoBehaviourSingleton<WestWorldDisplayer> 
{	
	#region Declarations
	
	private class DisplayItems
	{
		public DisplayItems(IList<string> items)
		{
			this.items = items;
			this.display = true;
			this.scrollPosition = new Vector2(0,0);
		}
			
		public IList<string> items;
		public bool display;
		public Vector2 scrollPosition;
	}
	
	private IDictionary<string, DisplayItems> _itemLists = new Dictionary<string, DisplayItems>();
	
	private Rect _backgroundRect = new Rect(0, 0, Screen.width, Screen.height);
	private Rect _containerRect = new Rect(Screen.width/4, 20, Screen.width/2, Screen.height-40);
	private GUIStyle _backgroundStyle;
	private GUIStyle _containerStyle;
	private GUIStyle _titleStyle;
	private GUIStyle _textStyle;
	private GUIStyle _toggleStyle;
	
	#endregion
	
	#region MonoBehaviour Members
	
	void Start()
	{
		_titleStyle = new GUIStyle();
		_titleStyle.fontSize = 48;
		_titleStyle.fontStyle = FontStyle.Bold;
		_titleStyle.normal.textColor = new Color(0,0,0);
		_titleStyle.alignment = TextAnchor.MiddleCenter;
		_titleStyle.font = Resources.Load("BleedingCowboys") as Font;
		
		_textStyle = new GUIStyle();
		_textStyle.normal.textColor = new Color(0,0,0);
		_textStyle.margin = new RectOffset(0,0,5,5);
		
		_toggleStyle = new GUIStyle();
		_toggleStyle.normal.textColor = new Color(0,0,0);
		_toggleStyle.onNormal.textColor = new Color(1,1,1);
		_toggleStyle.onNormal.background = Resources.Load("active") as Texture2D;
		_toggleStyle.margin = new RectOffset(5,5,5,5);
		_toggleStyle.padding = new RectOffset(5,5,5,5);
		_toggleStyle.font = Resources.Load("BleedingCowboys") as Font;
		
		_containerStyle = new GUIStyle();
		_containerStyle.padding = new RectOffset(10,10,10,10);
		_containerStyle.normal.background = Resources.Load("OldPaper") as Texture2D;
		
		_backgroundStyle = new GUIStyle();
		_backgroundStyle.normal.background = Resources.Load("WoodenWall") as Texture2D;
	}
	
	void OnGUI()
	{
		GUILayout.BeginArea(_backgroundRect, _backgroundStyle);
		GUILayout.BeginArea(_containerRect, _containerStyle);
		
		GUILayout.Label("West World", _titleStyle);
		
		var names = this._itemLists.Keys;
		
		GUILayout.BeginHorizontal();
		foreach(var name in names)
		{
			this._itemLists[name].display = GUILayout.Toggle(this._itemLists[name].display, name, _toggleStyle);	
		}
		GUILayout.EndHorizontal();
		
		foreach(var name in names)
		{
			var currentItems = this._itemLists[name];
			if(currentItems.display)
			{
				currentItems.scrollPosition = GUILayout.BeginScrollView(currentItems.scrollPosition);
				foreach(var item in currentItems.items)
				{
					GUILayout.Label(string.Format("{0}: {1}", name, item), _textStyle);
				}
				GUILayout.EndScrollView();
			}
		}
		
		GUILayout.EndArea();
		GUILayout.EndArea();
	}
	
	#endregion
	
	public void AddItem(string name, string item)
	{
		if(this._itemLists.ContainsKey(name)) 
		{
			this._itemLists[name].items.Add(item);
			this._itemLists[name].scrollPosition = new Vector2(this._itemLists[name].scrollPosition.x, Mathf.Infinity);
		}
		else
		{
			this._itemLists.Add(name, new DisplayItems(new List<string> { item }));
		}
	}
}
