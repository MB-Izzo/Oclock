using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour, IFreezable {

	private bool _is_freeze;
	private ButtonState _button_state;
	public ButtonState button_state { get { return this._button_state; } }

	// Use this for initialization
	void Start () {
		_button_state = ButtonState.UNPUSHED;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Freeze()
	{
	}

	public void UnFreeze()
	{
	}

	private void OnTriggerStay2D(Collider2D col)
	{
		if (col.gameObject.CompareTag(MyStrings.PLAYER_TAG))
		{
			_button_state = ButtonState.PUSHED;
		}
	}

	private void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.CompareTag (MyStrings.PLAYER_TAG))
		{
			_button_state = ButtonState.UNPUSHED;
		}
	}
}

public enum ButtonState {
	PUSHED,
	UNPUSHED,
	PUSHED_FREEZE,
	UNPUSHED_FREEZE
}
