using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUCK : MonoBehaviour
{
	public delegate void GoalHandler();
	public event GoalHandler OnGoal;

	public float Dcel;
	public float initHoriPos;

	private Rigidbody puckRigidbody;

    // Start is called before the first frame update
    void Start()
    {
		puckRigidbody = gameObject.GetComponent<Rigidbody> ();
		ResetPosition (true);
    }


    void FixedUpdate()
    {
		puckRigidbody.velocity = new Vector3 (
			puckRigidbody.velocity.x * Dcel,
			puckRigidbody.velocity.y * Dcel,
			puckRigidbody.velocity.z * Dcel
		);
	}

		void OnCollisionEnter (Collision colli) {

			if (colli.gameObject.tag == "Goal") {
				if (OnGoal != null) {
					OnGoal ();
				}

		} else {
			gameObject.GetComponent<AudioSource> ().Play ();
		}

		}
		 public void ResetPosition (bool isLeft) {
			transform.position = new Vector3 (
				initHoriPos * (isLeft ? -1 : 1),
				transform.position.y,
				transform.position.z
			);

		puckRigidbody.velocity = Vector3.zero;
	}
}
