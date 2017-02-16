using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerLightTorch : MonoBehaviour 
{
	private Light _Light;

	private void Start() 
	{
		_Light = this.GetComponent<Light>();

		StartCoroutine("ToggleIntensity");
	}

	private IEnumerator ToggleIntensity()
	{
		_Light.intensity = Random.Range(0.9f, 1.1f);

		yield return new WaitForSeconds(Random.Range (0.05f, 0.1f));

		StartCoroutine("ToggleIntensity");
	}

	public bool Enabled 
	{
		get { return _Light.enabled; }
		set { _Light.enabled = value; }
	}
}