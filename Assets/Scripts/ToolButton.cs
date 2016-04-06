using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ToolButton : MonoBehaviour {

	private Sprite ToolTexture;

	// Use this for initialization
	void Start () {
		ToolTexture = GetComponentInParent<Image>().overrideSprite;
		GetComponentInParent<Toggle> ().onValueChanged.AddListener (OnToggle);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnToggle(bool newVal)
	{
		if (newVal == true) {
			Cursor.SetCursor (ToolTexture.texture, Vector2.zero, CursorMode.Auto);
		} else {
			Cursor.SetCursor(null,Vector2.zero,CursorMode.Auto);
		}
	}
}
