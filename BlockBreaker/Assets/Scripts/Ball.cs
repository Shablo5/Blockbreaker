using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
    private Paddle paddle;
    private bool hasStarted = false;
    private Vector3 paddleToBallVector;

	// Use this for initialization
	void Start () {
        paddle = GameObject.FindObjectOfType<Paddle>();
        paddleToBallVector = this.transform.position - paddle.transform.position;                   // Calculate difference between THIS (ball) and the paddle's position. Outcome is Y since it starts above.
        
	}
	
	// Update is called once per frame
	void Update () {
        if (!hasStarted) {                                                                          // Check to see if 'hasStarted' is false/not true. Boolean.
        
        this.transform.position = paddle.transform.position + paddleToBallVector;                   // On every frame, lock THIS (ball) position to match that of paddle position(X) & paddleToBallVector(Y)
        
        if (Input.GetMouseButtonDown(0)) {                                                          // Wait for left (0) mouse button down.
            print("LEFT Mouse button pressed, launching ball");
            this.rigidbody2D.velocity = new Vector2(2f, 10f);                                       // Assign THIS (ball)'s rigidbody velocity to 2f(X), 10f(Y).
            hasStarted = true;                                                                      // Set 'hasStarted' to TRUE so this will no longer run
        }
            else if (Input.GetMouseButtonDown(1)) {

        }
                else if (Input.GetMouseButtonDown(2))
              {       
            }
        }
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        Vector2 tweak = new Vector2(Random.Range(0f, 0.8f), Random.Range(0f, 0.8f));
        if (hasStarted == true)
        {
            audio.Play();
            rigidbody2D.velocity += tweak;
        }

    }
}
