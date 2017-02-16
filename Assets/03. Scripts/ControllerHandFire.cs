using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerHandFire : MonoBehaviour 
{
	private const float TIME_TO_BURN = 1f;
	private const float TIME_TO_EXTINGUISH = 3f;

	[SerializeField]
	private ParticleSystem _ParticleSystem;

	private float _Timer;
	private float _TimerBurning;

	private bool _IsBurning;

	private void Start() 
	{
		_Timer = 0f;
		_TimerBurning = TIME_TO_BURN;

		_IsBurning = false;

		_ParticleSystem.Stop();
	}
	
	private void Update() 
	{
		if (_IsBurning)
			_Timer -= Time.deltaTime;

		if (_Timer <= 0f) 
		{
			_IsBurning = false;

			if (_ParticleSystem.isPlaying)
				_ParticleSystem.Stop();
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		_TimerBurning = TIME_TO_BURN;
	}

	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.tag.Equals("ObjectTorch")) 
		{
			if (other.gameObject.GetComponent<ParticleSystem>())
				_ParticleSystem = other.gameObject.GetComponent<ParticleSystem>();

			if (_IsBurning)
				_Timer = TIME_TO_EXTINGUISH;
			
			_TimerBurning -= Time.deltaTime;

			if (_TimerBurning <= 0f) 
			{
				_IsBurning = true;

				if (_IsBurning)
					_Timer = TIME_TO_EXTINGUISH;

				if (!_ParticleSystem.isPlaying)
					_ParticleSystem.Play();
				
			}
		}
	}
}