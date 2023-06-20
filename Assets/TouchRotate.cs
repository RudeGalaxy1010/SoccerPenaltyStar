using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchRotate : MonoBehaviour
{
	public Joystick joystick;
	public GameObject Object;
	Vector3 GameobjectRotation;
	private float GameobjectRotation2;
	private float GameobjectRotation3;

	public bool FacingRight = true;

    void Start()
    {
        joystick = GameObject.FindGameObjectWithTag("Joystick").GetComponent<Joystick>();
    }

	void Update()
	{
		//Gets the input from the jostick
		GameobjectRotation = new Vector3(joystick.Vertical, 0, joystick.Horizontal);

		GameobjectRotation3 = GameobjectRotation.x;

		if (FacingRight)
		{
			//Rotates the object if the player is facing right
			GameobjectRotation2 = GameobjectRotation.x + GameobjectRotation.z * 90 + 180;
			Object.transform.rotation = Quaternion.Euler(0f, GameobjectRotation2, 0);
		}
		else
		{
			//Rotates the object if the player is facing left
			GameobjectRotation2 = GameobjectRotation.x + GameobjectRotation.z * -90;
			Object.transform.rotation = Quaternion.Euler(0f, GameobjectRotation2, 0);
		}
		if (GameobjectRotation3 < 0 && FacingRight)
		{
			// Executes the void: Flip()
			Flip();
		}
		else if (GameobjectRotation3 > 0 && !FacingRight)
		{
			// Executes the void: Flip()
			Flip();
		}
	}
	private void Flip()
	{
		// Flips the player.
		FacingRight = !FacingRight;

		transform.Rotate(0, 180, 0);
	}
}
