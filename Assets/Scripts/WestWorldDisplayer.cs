using UnityEngine;
using System.Collections.Generic;

public class WestWorldDisplayer : MonoBehaviour 
{
	#region GameObject Singleton
	
	// NOTE: This component is designed to be created via Script, not in the editor
	
	private const string WEST_WORLD_DISPLAYER_NAME = "WestWorldDisplay";	
	private static WestWorldDisplayer _instance; 
	
	public static WestWorldDisplayer Instance
	{
		get 
		{
			return _instance ?? (_instance = (new GameObject(WEST_WORLD_DISPLAYER_NAME)).AddComponent<WestWorldDisplayer>());
		}
	}
	
	#endregion
	
	#region Declarations
	
	private IDictionary<string, IList<string>> _itemLists = new Dictionary<string, IList<string>>();
	private IDictionary<string, Vector2> _scrollPositions = new Dictionary<string, Vector2>();
	
	private Rect _backgroundRect = new Rect(0, 0, Screen.width, Screen.height);
	private Rect _containerRect = new Rect(Screen.width/4, 20, Screen.width/2, Screen.height-40);
	private GUIStyle _backgroundStyle;
	private GUIStyle _containerStyle;
	private GUIStyle _titleStyle;
	private GUIStyle _textStyle;
	
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
		
		foreach(var name in this._itemLists.Keys)
		{
			this._scrollPositions[name] = GUILayout.BeginScrollView(this._scrollPositions[name]);
			foreach(var item in this._itemLists[name])
			{
				GUILayout.Label(string.Format("{0}: {1}", name, item), _textStyle);
			}
			GUILayout.EndScrollView();
		}
		
		GUILayout.EndArea();
		GUILayout.EndArea();
	}
	
	#endregion
	
	public void AddItem(string name, string item)
	{
		if(this._itemLists.ContainsKey(name)) 
		{
			this._itemLists[name].Add(item);
			var scrollPosition = this._scrollPositions[name];
			scrollPosition.y = Mathf.Infinity;
		}
		else
		{
			this._itemLists.Add(name, new List<string> { item });
			this._scrollPositions.Add(name, new Vector2(0,0));
		}
	}
}
