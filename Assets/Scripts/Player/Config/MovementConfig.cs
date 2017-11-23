using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MovementConfig", menuName = "Player/MovementConfig", order = 1)]
public class MovementConfig : ScriptableObject {

	public float speed;
	public float jump_height;
	public float time_to_jump_apex;


}
