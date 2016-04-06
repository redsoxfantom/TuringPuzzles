using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class ToolHandler : MonoBehaviour {

	public ITool SelectedTool{ private get; set;}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ExecuteTool()
	{
		if (SelectedTool != null) {
			SelectedTool.Execute();
		}
	}
}
