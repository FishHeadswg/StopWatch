/*
Author: Trevor Richardson
StopWatch.cs
01-27-2015

	Stop watch for tracking time. As with most clocks, the second hand
	increments discretely while the minute hand increments continuously.
	Spacebar starts/stops watch, Escape resets it.
	
 */

using UnityEngine;
using System.Collections;

public class StopWatch : MonoBehaviour {

	GameObject outer;
	GameObject minute;
	GameObject second;
	// sentinel for spacebar
	private int space = 0;
	// used to increment seconds hand discretely
	private float time = 0f;
	// track time in Unity inspector
	public float debug = 0f;
	
	void Start () {
		// pause time until space is pressed
		Time.timeScale = 0f;

		// get objects by their tags
		outer = GameObject.FindGameObjectWithTag ("Outer");
		minute = GameObject.FindGameObjectWithTag ("Min");
		second = GameObject.FindGameObjectWithTag ("Sec");

		// init with red outline
		outer.renderer.material.color = Color.red;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
		{
			if (space % 2 == 1)
			{
				// pause time
				Time.timeScale = 0f;

				outer.renderer.material.color = Color.red;
			}
			else
			{
				// unpause time
				Time.timeScale = 1f;

				outer.renderer.material.color = Color.green;
			}
			++space;
		}
		// reset stop watch
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			space = 0;
			Time.timeScale = 0f;
			outer.renderer.material.color = Color.red;
			// reset rotation
			second.transform.rotation = Quaternion.identity;
			minute.transform.rotation = Quaternion.identity;
		}
		// debug = Time.time;
		minute.transform.Rotate(new Vector3(0, 0, (-6 * Time.deltaTime)/60f));
		// increment seconds hand by the second , resets after 1 second
		time += Time.deltaTime;
		second.transform.Rotate(new Vector3(0, 0, -(Mathf.Floor(time) * 6f)));
		if (time > 1f) time -= 1;
	}
}
