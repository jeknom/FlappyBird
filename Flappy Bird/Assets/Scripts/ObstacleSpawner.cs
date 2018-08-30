using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleSpawner : MonoBehaviour {

	[Header("OBSTACLE OBJECT")]
	[Tooltip("This variable contains the GameObject that is being spawned.")]
	public GameObject obstacle;

	[Header("MODIFIERS")]
	[Tooltip("This string needs to be named after the current scene or otherwise this script will be removed from the GameObject this is attached to.")]
	public string activeSceneName;

	[Tooltip("This variable changes the interval at which the obstacles are being spawned.")]
	public float spawnDelay;

	[Tooltip("This will set the initial spawn position for the obstacle. You might want to set this off camera to avoid flashing objects.")]
	public Vector3 initialStartPosition;

	[Tooltip("This boolean will decide if the object spawner will spawn objects or not.")]
	public bool toggleSpawner = true;
	
	void OnEnable()
	{
		// Checks if the scene name matches the string and if not, removes this script component from the GameObject.
		if (SceneManager.GetActiveScene().name != activeSceneName)
		{
			Debug.Log("Removing the ObstacleSpawner script from " + gameObject.name + ". Did you remember to set the scene in inspector?");
			Destroy(gameObject.GetComponent<ObstacleSpawner>());
		}

		// Makes sure that spawn delay is a positive value.
		spawnDelay = Mathf.Abs(spawnDelay);

		// Checks if the spawn delay has been set to something other than 0 and makes a note to console if it hasn't.
		if (spawnDelay == 0)
		{
			Debug.Log(gameObject.name + "s spawn delay was set to 0. You might have forgotten to set an value for it.");
		}

		// This one checks if the obstacle spawner has been turned on or not in inspector and if it is off, prints a notification to the console about this.
		if (!toggleSpawner)
		{
			Debug.Log("Obstacle spawning has been turned off in the inspector for " + gameObject.name);
		}

		//When the GameObject containing this script is added to the scene it will run the obstacle spawner coroutine.
		StartCoroutine(delayedObjectSpawner());
	}

	// This method will spawn new obstacles with an interval that was previously defined.
	IEnumerator delayedObjectSpawner()
	{
		// This while loop will run as long as the GameState component says that player is alive.
		while(gameObject.GetComponent<GameState>().isDead() == false)
		{
			// If the toggle spawner boolean was set true the spawner will start creating obstacle GameObjects into the-
			// scene with the intervals set into the spawnDelay variable.
			if (toggleSpawner)
			{
				// The instantiate will take a GameObject, Vector3 position and the rotation and then clone the obejct to that position with the rotation.
				// Here the instantiated obstacle is set to the local variable.
				GameObject instantiatedObstacle = Instantiate(obstacle, initialStartPosition, Quaternion.identity);
				yield return new WaitForSeconds(spawnDelay);
			}
			// If the toggle spawner boolean was set false, the loop will be broken...
			else
			{
				break;
			}
		}
	// ...and this console stirng will be printed indicating that the loop was broken due to the boolean being set false in inspector or by the player dying.
	Debug.Log("The spawner loop got broken, because spawner was toggled off in inspector or the player died..");
	}
}
