using UnityEngine;
using System.Collections;

public class BrickDamage : MonoBehaviour {

    public static int breakableCount = 0;
    public Sprite[] hitSprites;
    public SpriteRenderer spriteRender;
    public AudioClip crack;
    private int timesHit;
    private bool isBreakable;
    private LevelManager levelManager;
	// Use this for initialization
	void Start () {
        spriteRender = GetComponent<SpriteRenderer>();                                              // Set spriteRender to handle constant GetComponent requests
        levelManager = GameObject.FindObjectOfType<LevelManager>();                                 // I... Don't remember what this is. Lol
        timesHit = 0;                                                                               // Set initial value of timesHit for the block
        isBreakable = (this.tag == "Breakable");                                                    // A check to see if a block has breakable tag
        if (isBreakable)                                                                            // If the brick that has this script is breakable, then
        {
            breakableCount++;                                                                       // Increment breakableCount by 1
            print("Total breakable blocks left: " + breakableCount);
        }
    }

    void OnCollisionEnter2D(Collision2D col) {
        AudioSource.PlayClipAtPoint(crack, transform.position);
        if (isBreakable) {                                                                          // If it is true, call HitHandler method
        HitHandler();
        }
    }

    void HitHandler() {
        timesHit++;                                                                                 // Increment times hit by 1
        int maxHits = hitSprites.Length + 1;                                                        // Declare maxHits integer to be set as the number of items in the hitSprites array + 1
        if (timesHit >= maxHits)                                                                    // Check to see if timesHit is greater than or equal to the maxHits of a block
        {   
            breakableCount--;                                                                       // Decrease the total breakableCount 
            Destroy(gameObject);                                                                    // Destroy
            levelManager.BrickDestroyed();
        }
        else
        {
            LoadSprites();                                                                          // Or else, run the LoadSprites method
        }
    }

    void LoadSprites() {
        int spriteIndex = timesHit - 1;                                                             // The sprite chosen is the times it was hit, -1. Hit once? Sprite index [0]
        if (hitSprites[spriteIndex])                                                                // Check to see if there is a sprite in the spriteIndex. If null, it fails and doesn't change
        {
            spriteRender.sprite = hitSprites[spriteIndex];                                          // Change sprite to hitSprites array (sprites assigned in inspector), the 
        }                                                                                           // number associated with the sprite is determined by the previous line of code
    }                                                                                               

    // TODO remove this method when we can win.
    void SimulateWin() {
        levelManager.LoadNextLevel();
    }

	// Update is called once per frame
	void Update () {
	
	}
}
