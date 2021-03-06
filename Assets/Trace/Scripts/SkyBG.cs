﻿using UnityEngine;
using System.Collections;

public class SkyBG : MonoBehaviour {
	
	private Camera m_Camera = null;					// Handle Orthographic Camera in the scene
	
	Vector3 LeftMostOfScreen;						// Vector3 of middle-left most position at the edge of the camera view
	Vector3 RightMostOfScreen;						// Vector3 of middle-right most position at the edge of the camera view

	// Use this for initialization
	void Start () {

		// Find an Orthographic camera in the scene
		FindTheOrthographicCamera();

		// Strength this gameObject to fit the camera view
		this.transform.localScale = new Vector3((RightMostOfScreen.x-LeftMostOfScreen.x)/this.GetComponent<Renderer>().bounds.size.x, (m_Camera.orthographicSize*2)/this.GetComponent<Renderer>().bounds.size.y, 1);
	}

	// Find an Orthographic camera in the scene
	void FindTheOrthographicCamera()
	{
		if(m_Camera==null)
		{
			Camera[] CameraList = FindObjectsOfType<Camera>();
			foreach(Camera child in CameraList)
			{
				if(child.orthographic==true)
				{
					// Keep only first Orthographic Camera
					m_Camera = child;
					break;
				}
			}
		}
		
		// Calculate Left/Right most position at the edge of camera view
		if(m_Camera!=null)
		{
			LeftMostOfScreen = m_Camera.ScreenToWorldPoint(new Vector3(0, 0, 0));
			RightMostOfScreen = m_Camera.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0));
		}
	}
}