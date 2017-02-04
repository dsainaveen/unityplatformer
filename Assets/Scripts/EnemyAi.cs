using UnityEngine;
using System.Collections;

public class EnemyAi : MonoBehaviour {
	public float fpsTargetDistance;
	public float enemyLookDistance;
	public float attackDistance;
	public float damping;
	public float enemyMovementSpeed;
	public Transform fpsTransform;
	Rigidbody theRigidbody;
	Renderer theRenderer;


	// Use this for initialization
	void Start () { 
		theRenderer = GetComponent<Renderer> ();
		theRigidbody = GetComponent<Rigidbody> ();

	
	}
	
	// Update is called once per frame
	void Update () {

		fpsTargetDistance = Vector3.Distance (fpsTransform.position, transform.position);
		if (fpsTargetDistance < enemyLookDistance) {
			theRenderer.material.color = Color.yellow;
			lookAtPlayer ();


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
		theRigidbody.AddForce (transform.forward * enemyMovementSpeed);
		
	}


}