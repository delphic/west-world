using UnityEngine;
using System.Collections;

public class MonoBehaviourSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
	// NOTE: This these components are designed to be created via Script by accessing Instance, not via the editor
	
	private const string SINGLETON_NAME = "Singletons";	
	private static T _instance; 
	
	public static T Instance
	{
		get 
		{
			if(_instance == null) 
			{
				var gameObject = GameObject.Find(SINGLETON_NAME);
				if(gameObject == null) { gameObject = new GameObject(SINGLETON_NAME); }
				_instance = gameObject.GetComponent<T>() ?? gameObject.AddComponent<T>();
			}
			return _instance;
		}
	}
}
