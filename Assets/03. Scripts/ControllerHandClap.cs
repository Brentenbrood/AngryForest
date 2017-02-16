using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerHandClap : MonoBehaviour 
{
	private const float TIME_BETWEEN_CLAP = 1f;

	[SerializeField] private GameObject _ObjectOtherHand;
	[SerializeField] private Light _Light;

	private float _Timer;
	private bool _HasClapped;

	private void Start() 
	{
		_Timer = 0f;
		_HasClapped = false;
	}

	private void Update() 
	{
		_Timer -= Time.deltaTime;

		if (_Timer <= 0f)
			_HasClapped = false;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.Equals(_ObjectOtherHand)) 
		{
			if (_HasClapped && _Timer > 0f) 
			{
				_HasClapped = false;

				// do something
				_Light.enabled = !_Light.enabled;
			} 
			else 
			{
				_Timer = TIME_BETWEEN_CLAP;
				_HasClapped = true;
			}
		}
	}

	private void OnTriggerStay(Collider other)
	{

	}

	private void OnTriggerExit(Collider other)
	{
		
	}
}