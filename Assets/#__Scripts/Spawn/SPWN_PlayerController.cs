using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPWN_PlayerController : MonoBehaviour
{
	Vector3 movement;
	Rigidbody rb;
	float moveX;                                    // Horizontal movement input
	float moveZ;                                    // Vertical movement input
	public bool isMoving { get; protected set; }
	public float moveSpeed;
	public Animator anim;

	private void OnEnable()
	{
		// If the is a rigidbody assign it, if not create it
		if (this.gameObject.GetComponent<Rigidbody>() != null)
			rb = this.gameObject.GetComponent<Rigidbody>();
		else
			rb = this.gameObject.AddComponent<Rigidbody>();
	}
    
    void Update()
    {
		MovementInput();
		Rotation();
		Animation();
    }

	private void FixedUpdate()
	{
		MovementPhysics();
	}


	void MovementInput()
	{
		moveX = Input.GetAxisRaw("Horizontal");
		moveZ = Input.GetAxisRaw("Vertical");

		if (moveX != 0 || moveZ != 0)
			isMoving = true;
		else
			isMoving = false;
	}

	

	void MovementPhysics()
	{
		rb.velocity = new Vector3(moveX, 0, moveZ).normalized * moveSpeed;

		/*
        print("Hey guys, MovementPhysics() here! Just making sure I am working correctly, you know haha. Can't be too sure these days. " +
              "Oh! I almost forgot haha, here read this: " + new Vector3(moveX, 0, moveY).normalized * currentMovementSpeed);
        */
	}

	void Rotation()
	{
		if (moveX != 0 || moveZ != 0)
			this.gameObject.transform.eulerAngles = new Vector3(0, Mathf.Atan2(moveZ, -moveX) * Mathf.Rad2Deg - 90, 0);
	}

	void Animation()
	{
		if (moveX != 0 || moveZ != 0)
			anim.SetBool("Moving", true);
		else
			anim.SetBool("Moving", false);
	}
}
