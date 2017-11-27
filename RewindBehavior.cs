using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewindBehavior : MonoBehaviour {

	private List<Vector2> positionList = new List<Vector2>();
	private GameObject Player;
	public Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		InvokeRepeating ("LogProgress", 0.1f, 0.1f);
		Player = this.gameObject;
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update(){
		if (Input.GetKeyDown (KeyCode.Space)) {
			CancelInvoke ();
			rb.isKinematic = true;
			InvokeRepeating ("RewindTime", 0.01f, 0.01f);
		}
	}
	void LogProgress(){

		positionList.Add (Player.transform.position);

		if (positionList.Count > 50) {
			positionList.RemoveAt (0);
		}
		Debug.Log (positionList[positionList.Count-1]);
	}
	
	void RewindTime(){
		if (positionList.Count > 0) {
			Player.transform.position = positionList [positionList.Count - 1];
			positionList.RemoveAt (positionList.Count - 1);
		} else {
			CancelInvoke ();
			rb.isKinematic = false;
			InvokeRepeating ("LogProgress", 0.5f, 0.5f);
		}
			
	}
			
}
