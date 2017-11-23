using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovePlayer : MonoBehaviour {

	private Vector3 _delta;
	private PlayerMovement _player;
	
	// Use this for initialization
	void Start () {
		_player = FindObjectOfType<PlayerMovement> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.CompareTag (MyStrings.PLAYER_TAG))
		{
			_delta = transform.position;
		}
	}

	private void OnCollisionStay2D(Collision2D col)
	{
		if (col.gameObject.CompareTag (MyStrings.PLAYER_TAG))
		{
			_player.transform.position += transform.TransformDirection (transform.position - _delta);
			_delta = transform.position;
		}
	}
}
