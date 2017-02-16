using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Description: 
 * Controls the flickering of the given light.
 */

[RequireComponent(typeof(Light))]
public class ControllerLight : MonoBehaviour 
{
	private Light _Light;

	[Tooltip("The minimum delay to turn the light on/off in seconds.")]
	[SerializeField]
	[Range(0.01f, 5f)]
	private float _DurationMin;

	[Tooltip("The maximum delay to turn the light on/off in seconds.")]
	[SerializeField]
	[Range(0.01f, 5f)]
	private float _DurationMax;


	/*
	 * Description: Executed when the GameObject becomes active.
	 */
	private void Start() 
	{
		_Light = this.GetComponent<Light>();

		_Light.enabled = false;

		StartCoroutine("ToggleLight");
	}


	/*
	 * Description: Executed every random generated time between _DurationMin and _DurationMax.
	 */
	private IEnumerator ToggleLight()
	{
		_Light.enabled = !_Light.enabled;

		yield return new WaitForSeconds(Random.Range(_DurationMin, _DurationMax));

		StartCoroutine("ToggleLight");
	}
}