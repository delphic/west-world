using UnityEngine;
using System.Collections;

public abstract class AgentBase : MonoBehaviour 
{
	// Base class for Agents
	// Used to ensure correct types are used in various generics
	// and to allow different agent references to be grouped in collections   
	// without resorting to using MonoBehaviour, GameObject or object
	
	public abstract System.Type AgentType { get; }
}
