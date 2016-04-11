using UnityEngine;
using System.Collections;
using AssemblyCSharp;
using UnityEngine.UI;

public class ToolHandler : MonoBehaviour {

	public ITool SelectedTool{ get; set;}
	public Image ToolImage{ private get; set; }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public bool TryGetToolImage(out Image ToolImage)
	{
		ToolImage = null;
		if (SelectedTool != null) {
			if(SelectedTool.CanUseImage()) {
				ToolImage = this.ToolImage;
				return true;
			}
		}
		return false;
	}
}
