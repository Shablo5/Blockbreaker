using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

    public bool autoPlay = false;
    private Ball ball;

    void Start() {
        ball = GameObject.FindObjectOfType<Ball>();
    }
	

	void Update () {
        if (autoPlay == false)
        {
            MoveWithMouse();
        }
        else {
            AutoPlay();
        }
	}

    void MoveWithMouse() {
        Vector3 paddlePos = new Vector3(1.05f, this.transform.position.y, 0f);                  // x,y,z
        float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;                     // Mouse position X plane divided by the screen width, multiplied by the world units.
        paddlePos.x = Mathf.Clamp(mousePosInBlocks, 1.05f, 14.96f);                             // Take current mouse position in blocks (variable) and transform paddle's X plane to match. Clamp between 0.5f and 15.5f.
        this.transform.position = paddlePos;
    }

    void AutoPlay()
    {
        Vector3 paddlePos = new Vector3(1.05f, this.transform.position.y, 0f);                      // x,y,z
        Vector3 ballPos = ball.transform.position;
        paddlePos.x = Mathf.Clamp(ballPos.x, 1.05f, 14.96f);                                        // Take current mouse position in blocks (variable) and transform paddle's X plane to match. Clamp between 0.5f and 15.5f.
        this.transform.position = paddlePos;
    }
}
