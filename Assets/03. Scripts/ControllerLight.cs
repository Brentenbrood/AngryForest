using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerLight : MonoBehaviour 
{
	private Light _Light;

	[SerializeField]
	[Range(0.01f, 5f)]
	private float _DurationMin;

	[SerializeField]
	[Range(0.01f, 5f)]
	private float _DurationMax;

	private void Start() 
	{
		_Light = this.GetComponent<Light>();

		_Light.enabled = false;

		StartCoroutine("ToggleLight");
	}

	private IEnumerator ToggleLight()
	{
		_Light.enabled = !_Light.enabled;

		yield return new WaitForSeconds(Random.Range(_DurationMin, _DurationMax));

		StartCoroutine("ToggleLight");
	}
}