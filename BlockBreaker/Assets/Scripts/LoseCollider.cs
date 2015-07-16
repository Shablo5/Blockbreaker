using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

    private LevelManager levelManager;                                                              // Declare LevelManager(script) type variable called levelManager.

    void OnTriggerEnter2D (Collider2D collider) {
        Application.LoadLevel("Lose");                                                              // On Trigger with Bottombounds, load level "Win".
    }

    void Start() {                                                                                  // On start.
        levelManager = GameObject.FindObjectOfType<LevelManager>();                                 // levelManager variable is to assign itself to object LevelManager.
    }
}
