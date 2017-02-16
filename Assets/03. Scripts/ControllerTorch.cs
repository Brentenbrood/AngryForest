using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerTorch : MonoBehaviour 
{
	private const float TIME_TO_BURN = 2f;
	private const float TIME_TO_EXTINGUISH = 30f;

	[SerializeField] private bool _CanExtinguish;

	[SerializeField] private ParticleSystem _ParticleSystem;
	[SerializeField] private AudioSource _AudioEffectFire;

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
		if (_IsBurning && _CanExtinguish)
			_Timer -= Time.deltaTime;

		if (_Timer <= 0f) 
		{
			_IsBurning = false;

			_AudioEffectFire.Stop();

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

				_AudioEffectFire.Play();

				if (_IsBurning)
					_Timer = TIME_TO_EXTINGUISH;

				if (!_ParticleSystem.isPlaying)
					_ParticleSystem.Play();

			}
		}
	}

	public bool IsBurning 
	{
		get { return _IsBurning; }
	}
}