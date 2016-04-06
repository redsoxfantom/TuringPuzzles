using UnityEngine;
using System.Collections;
using AssemblyCSharp;
using UnityEngine.UI;

public class ToolHandler : MonoBehaviour {

	public ITool SelectedTool{ get; set;}
	public Image ToolImage{ get; set; }

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
