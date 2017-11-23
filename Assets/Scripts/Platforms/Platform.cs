using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Platform : MonoBehaviour {



	public float speed;
	protected float _speed { get { return this.speed; } set { this.speed = value; } }

	protected float _initial_speed;

	protected virtual void OnStart()
	{
		_initial_speed = _speed;
	}
}

