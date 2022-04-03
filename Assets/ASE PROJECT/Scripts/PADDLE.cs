using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PADDLE : MonoBehaviour
{

	public int playNum;
	public float SP;

	private Rigidbody paddleRigidbody;

    // Start is called before the first frame update
    void Start()
    {
		paddleRigidbody = gameObject.GetComponent<Rigidbody> ();
    }

    // Update is called once per frame
    void Update()
    {
		float horiMovement = Input.GetAxis("HORIZONTAL" + playNum) * SP;
		float vertiMovement = Input.GetAxis("VERTICAL" + playNum) * SP; 

		paddleRigidbody.velocity = new Vector3 (horiMovement, 0, vertiMovement);

    }
}
