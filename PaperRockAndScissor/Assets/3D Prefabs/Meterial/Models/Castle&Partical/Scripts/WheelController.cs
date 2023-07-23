using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class WheelController : MonoBehaviour {

	
	[FormerlySerializedAs("rotateDirection")] public Vector3 _rotateDirection;
	[FormerlySerializedAs("rotateSpeed")] public float _rotateSpeed;
	[FormerlySerializedAs("isRotating")] public bool _isRotating;

	
	void Update () 
	{
		if(_isRotating)
		{
			//Rotate the selected wheel in the direction
			//chosen at rotateSpeed Speed
			//if isRotating is checked in the inspector.
			transform.Rotate(_rotateDirection * _rotateSpeed * Time.deltaTime);
		}
		
	}
}
