using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public MovementConfig movement_config;

	private Rigidbody2D _rb;

	private Vector2 _input;

	private GroundChecker _ground_checker;
	private bool _grounded { get { return _ground_checker.is_grounded; } }

	private float _speed { get { return movement_config.speed; } }
	private float _jump_height { get { return movement_config.jump_height; } }
	private float _time_to_jump_apex { get { return movement_config.time_to_jump_apex; } }

	private float _gravity;
	private float _jump_velocity;


	// Use this for initialization
	void Start () {
		_rb = GetComponent<Rigidbody2D> ();
		_ground_checker = GetComponentInChildren<GroundChecker> ();
		SetGravity ();
	}

	private void FixedUpdate()
	{
		_input = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
		_rb.velocity = new Vector2 (_input.x * _speed, _rb.velocity.y);
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) && _grounded)
		{
			Jump ();
		}
	}

	private void Jump()
	{
		_rb.velocity = new Vector2 (_rb.velocity.x, _jump_velocity);
	}

	private void SetGravity()
	{
		_gravity = -(2 * _jump_height) / Mathf.Pow (_time_to_jump_apex, 2);
		_jump_velocity = Mathf.Abs (_gravity) * _time_to_jump_apex;
		_rb.gravityScale = -_gravity;

	}
}
