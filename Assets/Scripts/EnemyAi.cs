using UnityEngine;
using System.Collections;

public class EnemyAi : MonoBehaviour {
	public float fpsTargetDistance;
	public float enemyLookDistance;
	public float attackDistance;
	public float damping;
	public float enemyMovementSpeed;
	public Transform fpsTransform;
	Rigidbody2D theRigidbody;
	Renderer theRenderer;
	Vector2 dir;


	// Use this for initialization
	void Start () { 
		theRenderer = GetComponent<Renderer> ();
		theRigidbody = GetComponent<Rigidbody2D> ();

	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		fpsTargetDistance = Vector2.Distance (fpsTransform.position, transform.position);
		if (fpsTargetDistance < enemyLookDistance) {
			theRenderer.material.color = Color.yellow;
			//lookAtPlayer ();


			if(fpsTargetDistance<attackDistance){
				theRenderer.material.color = Color.red;
				attackPlayer ();
				
			}

		}

	}
	void lookAtPlayer(){
		Quaternion rotation = Quaternion.LookRotation(fpsTransform.position - transform.position);
		transform.rotation = Quaternion.Slerp(transform.rotation,rotation,Time.deltaTime*damping);
		
	}

	void attackPlayer(){
		var relativedir = transform.InverseTransformPoint (fpsTransform.position);

		if (relativedir.x < 0.0)
			theRigidbody.AddForce (-transform.right * enemyMovementSpeed);
		else if(relativedir.x>0.0)
			theRigidbody.AddForce (transform.right * enemyMovementSpeed);
		
	}


}