using UnityEngine;
using System.Collections;

public class SpriteChanging : MonoBehaviour {
    // Block assigning variables
    public static int breakableCount;
    public Sprite blueblock;
    public Sprite redblock;
    public Sprite yellowblock;
    public SpriteRenderer spriteRender;
    private LevelManager levelManager;                                                              // Handles level transition after game won

	void Start () {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        spriteRender = GetComponent<SpriteRenderer>();                                              // Set variable to handle constant GetComponent requests
        Sprite[] tempSprite = Resources.LoadAll<Sprite>("Sprites/Bricksheet");                      // Set START only Sprite array to point to Resources/Sprites/Bricksheet
        blueblock = tempSprite[0];                                                                  // Set blocks to sprites
        yellowblock = tempSprite[1];
        redblock = tempSprite[2];
        spriteRender.sprite = redblock;                                                             // Set initial sprite to redblock so next method has a starting point
        if (this.tag == "Breakable") {
            breakableCount++;
            print("Total breakable blocks left: " + breakableCount);
        }
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")                                                         // Check to see if collision is from object with tag "Player"
        {
            if (spriteRender.sprite == redblock)                                                    // Check run check on block sprite
            {
                spriteRender.sprite = yellowblock;                                                  // Change sprite to different colored sprite
            }

            else if (spriteRender.sprite == yellowblock)
            {
                spriteRender.sprite = blueblock;
            }

            else if (spriteRender.sprite == blueblock)
            {
                breakableCount--;
                Destroy(gameObject);                                                                // Destroy blue block (last hit)
                levelManager.BrickDestroyed();
            }
        }
    }
	
}
