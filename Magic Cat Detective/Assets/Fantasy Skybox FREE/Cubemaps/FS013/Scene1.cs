using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scene1 : MonoBehaviour
{
	private TextMeshProUGUI textMesh;
	private GameObject badger;
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
    }
}
