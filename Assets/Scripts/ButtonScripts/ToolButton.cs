using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using AssemblyCSharp;

public class ToolButton : MonoBehaviour {

	private Sprite ToolTexture;
	private ITool ToolToExecute;
	public ToolHandler toolHandler;
	public ToolTypes ToolType;

	// Use this for initialization
	void Start () {
		ToolTexture = GetComponentInParent<Image>().overrideSprite;
		GetComponentInParent<Toggle> ().onValueChanged.AddListener (OnToggle);
		ToolToExecute = ToolFactory.GetTool (ToolType);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnToggle(bool newVal)
	{
		if (newVal == true) {
			Cursor.SetCursor (ToolTexture.texture, Vector2.zero, CursorMode.Auto);
			toolHandler.SelectedTool = ToolToExecute;
		} else {
			Cursor.SetCursor(null,Vector2.zero,CursorMode.Auto);
			toolHandler.SelectedTool = null;
		}
	}
}
