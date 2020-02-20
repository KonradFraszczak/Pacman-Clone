using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Pacmove : MonoBehaviour{
    
	float dirX, dirY;
	
	[Range(1f, 20f)]
	public float moveSpeed = 5f;
	
    void Update()
    {
			dirX = CrossPlatformInputManager.GetAxis ("Horizontal") * moveSpeed * Time.deltaTime;
			dirY = CrossPlatformInputManager.GetAxis ("Vertical") * moveSpeed * Time.deltaTime;
			
    		transform.position = new Vector2 (transform.position.x + dirX, transform.position.y + dirY);
	}
}

