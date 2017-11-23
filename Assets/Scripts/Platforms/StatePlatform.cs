using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatePlatform : Platform, IFreezable {

	public Transform posA;
	public Transform posB;
	private PlatformState _platform_state;
	public Button linked_button;
	private ButtonState linked_button_state;


	// Use this for initialization
	protected void Start () {
		base.OnStart ();
	}
	
	// Update is called once per frame
	void Update () {
		linked_button_state = linked_button.button_state;
		MoveAccordingButtonState ();
	}

	public void Freeze()
	{
		_speed = 0;
	}

	public void UnFreeze()
	{
		_speed = _initial_speed;
	}

	private void MoveToPosA()
	{
		if (posA.transform.position != transform.position)
		{
			Vector3 dir = (posA.transform.position - transform.position).normalized;
			transform.position += dir * _speed * Time.deltaTime;
			if (dir != (posA.transform.position - transform.position).normalized)
			{
				transform.position = posA.transform.position;
			}
		}
	}

	private void MoveToPosB()
	{
		if (posB.transform.position != transform.position)
		{
			Vector3 dir = (posB.transform.position - transform.position).normalized;
			transform.position += dir * _speed * Time.deltaTime;
			if (dir != (posB.transform.position - transform.position).normalized)
			{
				transform.position = posB.transform.position;
			}
		}
	}

	private void MoveAccordingButtonState()
	{
		switch (linked_button_state)
		{
		case ButtonState.PUSHED:
			MoveToPosB ();
			break;
		case ButtonState.UNPUSHED:
			MoveToPosA ();
			break;
		case ButtonState.PUSHED_FREEZE:
			MoveToPosB ();
			break;
		case ButtonState.UNPUSHED_FREEZE:
			MoveToPosA ();
			break;
		default:
			break;
		}
	}

}

public enum PlatformState {
	TO_POS_A,
	AT_POS_A,
	TO_POS_B,
	AT_POS_B,
	FREEZED
}