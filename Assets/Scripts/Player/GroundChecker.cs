using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour {

	private bool _is_grounded;
	public bool is_grounded { get { return _is_grounded; } }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		_is_grounded = true;
	}

	private void OnTriggerExit2D(Collider2D col)
	{
		_is_grounded = false;
	}
}
