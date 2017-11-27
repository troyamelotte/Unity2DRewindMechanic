using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	public float speed;
	public float jump;
	Rigidbody2D rb;
	public GameObject groundCheck;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit2D check = Physics2D.Raycast (groundCheck.transform.position, Vector2.down, 0.1f);
		if (Input.GetKey (KeyCode.RightArrow)) {
			rb.velocity = new Vector2 (speed, rb.velocity.y);
		} else if (Input.GetKey (KeyCode.LeftArrow)) {
			rb.velocity = new Vector2 (-speed, rb.velocity.y);
		}

		if (Input.GetKeyDown (KeyCode.UpArrow) && check.collider!=null) {
			rb.AddForce (Vector2.up * jump, ForceMode2D.Impulse);
		}

		if (Input.GetKeyUp (KeyCode.RightArrow) || Input.GetKeyUp (KeyCode.LeftArrow)) {
			rb.velocity = new Vector2 (0, rb.velocity.y);
		}
	}
}
