using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBlueController : MonoBehaviour {
	private Rigidbody2D blueRb2D;
	private Collider2D blueCo2D;
	public LayerMask groundLayer;

	private float moveSpeed;
	private float jumpForce = 5f;
	private float checkDistance = 0.1f;
	private bool isJumping;

	private float moveHorizontal;
	private bool inputJump;


	// Start is called before the first frame update
	void Start ()
	{
		blueRb2D = gameObject.GetComponent<Rigidbody2D> ();
		blueCo2D = gameObject.GetComponent<Collider2D> ();
		moveSpeed = 1f;
	}

	// Update is called once per frame
	void Update ()
	{
		moveHorizontal = Input.GetAxisRaw ("Horizontal");
		inputJump = Input.GetButtonDown ("Jump");
		// jump
		if (inputJump && IsGrounded ()) {
			blueRb2D.AddForce (Vector2.up * jumpForce, ForceMode2D.Impulse);
		}
	}

	private bool IsGrounded ()
	{
		Vector2 boxCastSize = new Vector2 (blueCo2D.bounds.size.x, checkDistance);
		RaycastHit2D hit = Physics2D.BoxCast (blueCo2D.bounds.center, boxCastSize, 0, Vector2.down, blueCo2D.bounds.extents.y + checkDistance, groundLayer);
		return hit.collider != null;
	}

	private void FixedUpdate ()
	{
		// move horizontal
		if (moveHorizontal < -0.1f || moveHorizontal > 0.1f) {
			blueRb2D.AddForce (Vector2.right * moveHorizontal * moveSpeed, ForceMode2D.Impulse);
		}

	}
}
