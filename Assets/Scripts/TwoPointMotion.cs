using UnityEngine;
using System.Collections;

public class TwoPointMotion : MonoBehaviour {
	public float speed;
	public Vector2 pointA;
	public Vector2 pointB;
	public bool reverseMove = false;
	private float startTime;
	private float journeyLength; 



	// Use this for initialization
	void Start () {
		startTime = Time.time;
		journeyLength = Vector2.Distance(pointA, pointB);
	}
	
	// Update is called once per frame
	void Update () {
		float distCovered = (Time.time - startTime) * speed;
		float fracJourney = distCovered / journeyLength;
		if (reverseMove)
		{
			transform.position = Vector2.Lerp(pointB, pointA, fracJourney);
		}
		else
		{
			transform.position = Vector2.Lerp(pointA, pointB, fracJourney);
		}
		if ((Vector2.Distance(transform.position, pointB) == 0.0f || Vector2.Distance(transform.position, pointA) == 0.0f)) //Checks if the object has travelled to one of the points
		{
			if (reverseMove)
			{
				reverseMove = false;
			}
			else
			{
				reverseMove = true;
			}
			startTime = Time.time;
		}
		
	}
}
