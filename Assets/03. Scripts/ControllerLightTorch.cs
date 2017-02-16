using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Description: 
 * Controls the randomly generated intensity of the given light.
 */

[RequireComponent(typeof(Light))]
public class ControllerLightTorch : MonoBehaviour 
{
	private Light _Light;

	/*
	 * Description: Executed when the GameObject becomes active.
	 */
	private void Start() 
	{
		_Light = this.GetComponent<Light>();

		StartCoroutine("ToggleIntensity");
	}


	/*
	 * Description: Executed every random generated time to change the intensity of the light.
	 */
	private IEnumerator ToggleIntensity()
	{
		_Light.intensity = Random.Range(0.9f, 1.1f);

		yield return new WaitForSeconds(Random.Range (0.05f, 0.1f));

		StartCoroutine("ToggleIntensity");
	}


	/*
	 * Description: get/set the Light.enabled property.
	 */
	public bool Enabled 
	{
		get { return _Light.enabled; }
		set { _Light.enabled = value; }
	}
}