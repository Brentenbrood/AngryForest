using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class ControllerTree : MonoBehaviour 
{
	private Rigidbody _Rigidbody;

	[SerializeField] private AudioSource _AudioEffectMove;
	[SerializeField] private AudioSource _AudioEffectFire;

	private Vector3 _Position;

	private const float TIME_TO_BURN = 1f;
	private const float TIME_TO_EXTINGUISH = 10f;

	[SerializeField]
	private bool _CanExtinguish;

	[SerializeField]
	private ParticleSystem _ParticleSystem;

	private float _Timer;
	private float _TimerBurning;

	private bool _IsBurning;

    private void Start() 
	{
		_Rigidbody = this.GetComponent<Rigidbody>();

		_Position = this.transform.position;
		_AudioEffectMove.time = 0.6f;

		_Timer = 0f;
		_TimerBurning = TIME_TO_BURN;

		_IsBurning = false;

		_ParticleSystem.Stop();
	}

	private void Update() 
	{
		if (_Rigidbody.velocity.magnitude > 0f)
			if (!_AudioEffectMove.isPlaying)
				_AudioEffectMove.Play();

		if (_Rigidbody.velocity.magnitude <= 0f)
			if (_AudioEffectMove.isPlaying)
				_AudioEffectMove.Stop();

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
		if (other.gameObject.tag.Equals("ObjectTorch") && other.gameObject.GetComponent<ControllerTorch>().IsBurning) 
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

	// Unused
	private IEnumerator FadeAudio(AudioSource audio, float time)
	{
		float volume = audio.volume;

		while (audio.volume > 0) 
		{
			audio.volume -= volume * Time.deltaTime / time;

			yield return null;
		}

		audio.Stop();
		audio.volume = volume;
	}
}