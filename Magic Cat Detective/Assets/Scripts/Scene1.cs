using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scene1 : MonoBehaviour
{
	private TextMeshProUGUI textMesh;
	private GameObject badger;
	private GameObject badgerWaypoint1;
    private float timeSinceStateTransition = 0.0f;

	enum SceneState {
		INITIAL,
		APPLEKIT,
		BADGER_APPEARS
	};
	private SceneState state;

    void Start()
    {	
		state = SceneState.INITIAL;
        textMesh = (TextMeshProUGUI)FindObjectOfType(typeof(TextMeshProUGUI));

		badger = GameObject.Find("Badger");
		badger.SetActive(false);

		badgerWaypoint1 = GameObject.Find("BadgerWaypoint1");
    }

	void SwitchStateTo(SceneState newState) {
		timeSinceStateTransition = 0.0f;
		state = newState;
		switch (newState) {
			case SceneState.APPLEKIT:
				textMesh.SetText("You are a kit, your name is Leaf");
				break;
			case SceneState.BADGER_APPEARS:
				textMesh.SetText("A badger appears");
				badger.SetActive(true);
				break;				
		}
		
	}

    // Update is called once per frame
    void Update()
    {
		timeSinceStateTransition += Time.deltaTime;
        if (state == SceneState.INITIAL) {
			if (timeSinceStateTransition > 5.0) {
				SwitchStateTo(SceneState.APPLEKIT);
			}
		}
		else if (state == SceneState.APPLEKIT) {
			if (timeSinceStateTransition > 5.0) {
				SwitchStateTo(SceneState.BADGER_APPEARS);
			}
		}
		else if (state == SceneState.BADGER_APPEARS) {
			Vector3 xzPosition = badger.transform.position;
			xzPosition.y = 0.0f;
			Vector3 direction = badgerWaypoint1.transform.position - xzPosition;
			if (direction.magnitude > 10.0f) {
				Debug.Log("Direction = " + direction.normalized);
				badger.transform.position += direction.normalized * 5 * Time.deltaTime;
			}
		}
    }
}
