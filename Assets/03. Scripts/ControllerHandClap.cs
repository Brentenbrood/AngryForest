using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Description: 
 * Controls the hand gesture of clapping by checking for collision between
 * two GameObjects between the specified maximum interval.
 * 
 * Only ONE hand GameObject needs to be given this script.
 */

public class ControllerHandClap : MonoBehaviour 
{
	// The maximum time between clapping for the gesture to work.
	private const float TIME_BETWEEN_CLAP = 1f;

	[Tooltip("The GameObject representing the other GameObject.")]
	[SerializeField] 
	private GameObject _ObjectOtherHand;

	[Tooltip("The Light to trigger when the user claps.")]
	[SerializeField] 
	private Light _Light;

	// Timer taking care of the interval the user is clapping in.
	private float _Timer;

	// Whether the user has clapped once or not.
	private bool _HasClapped;


	/*
	 * Description: Executed when the GameObject becomes active.
	 */
	private void Start() 
	{
		_Timer = 0f;
		_HasClapped = false;
	}


	/*
	 * Description: Executed every new frame.
	 */
	private void Update() 
	{
		_Timer -= Time.deltaTime;

		if (_Timer <= 0f)
			_HasClapped = false;
	}


	/*
	 * Description: Executed when the GameObject collides with a Collider.
	 */
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
}