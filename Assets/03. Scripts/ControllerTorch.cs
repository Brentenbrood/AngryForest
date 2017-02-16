using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Description: 
 * Controls the torch (GameObject) to be able to interact with 
 * other specific tagged GameObjects and allowing it to burn.
 */

[RequireComponent(typeof(ParticleSystem))]
public class ControllerTorch : MonoBehaviour 
{
	// The time it takes to start burning in particles in seconds.
	private const float TIME_TO_BURN = 5f;

	// The time it takes to automatically stop burning in particles in seconds.
	private const float TIME_TO_EXTINGUISH = 10f;

	[SerializeField] private bool _CanExtinguish;

	[Tooltip("The ParticleSystem to be used as a fire.")]
	[SerializeField] 
	private ParticleSystem _ParticleSystem;

	[Tooltip("The audio to use for the burning sound.")]
	[SerializeField] 
	private AudioSource _AudioEffectFire;

	// Timer taking care on how long the GameObject is touching a wanted Collider
	private float _Timer;

	// Timer taking care on how long the GameObject is burning in particles
	private float _TimerBurning;


	// Whether the GameObject is burning or not
	private bool _IsBurning;


	/*
	 * Description: Executed when the GameObject becomes active.
	 */
	private void Start() 
	{
		_Timer = 0f;
		_TimerBurning = TIME_TO_BURN;

		_IsBurning = false;

		_ParticleSystem.Stop();
	}


	/*
	 * Description: Executed every new frame.
	 */
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


	/*
	 * Description: Executed when the GameObject collides with a Collider.
	 */
	private void OnTriggerEnter(Collider other)
	{
		_TimerBurning = TIME_TO_BURN;
	}


	/*
	 * Description: Executed when the GameObject stays in collision with a Collider.
	 */
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