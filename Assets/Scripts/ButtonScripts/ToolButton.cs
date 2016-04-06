using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using AssemblyCSharp;

public class ToolButton : MonoBehaviour {

	private Image ToolTexture;
	private ITool ToolToExecute;
	public ToolHandler toolHandler;
	public ToolTypes ToolType;

	// Use this for initialization
	void Start () {
		ToolTexture = GetComponentInParent<Image>();
		GetComponentInParent<Toggle> ().onValueChanged.AddListener (OnToggle);
		ToolToExecute = ToolFactory.GetTool (ToolType);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnToggle(bool newVal)
	{
		if (newVal == true) {
			//Cursor.SetCursor (ToolTexture.texture, Vector2.zero, CursorMode.Auto);
			toolHandler.SelectedTool = ToolToExecute;
			toolHandler.ToolImage = ToolTexture;
		} else {
			//Cursor.SetCursor(null,Vector2.zero,CursorMode.Auto);
			toolHandler.SelectedTool = null;
			toolHandler.ToolImage = null;
		}
	}
}
