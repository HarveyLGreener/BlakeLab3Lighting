using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public CharacterController CC;
	public float MoveSpeed;
	public float Gravity = -9.8f;
	public float JumpSpeed;
	public float verticalSpeed;

	//Due to jump not working when standing still, I'm using "hasLanded" to check if grounded at any point.
	public bool hasLanded = true;

	private void Update()
	{
		Vector3 movement = Vector3.zero;
		// X/Z movement
		float forwardMovement = Input.GetAxis("Vertical") * MoveSpeed * Time.deltaTime;
		float sideMovement = Input.GetAxis("Horizontal") * MoveSpeed * Time.deltaTime;

		movement += (transform.forward * forwardMovement) + (transform.right * sideMovement);
		if (CC.isGrounded)
		{
			verticalSpeed = 0f;
			hasLanded = true;
		}
		if ((Input.GetKeyDown(KeyCode.Space)) & (-0.6 < verticalSpeed) & (verticalSpeed <= 0f) & (hasLanded == true))
		{
			hasLanded = false;
			verticalSpeed = JumpSpeed;
		}

		verticalSpeed += (Gravity * Time.deltaTime);
		movement += (transform.up * verticalSpeed * Time.deltaTime);

		CC.Move(movement);
	}
}