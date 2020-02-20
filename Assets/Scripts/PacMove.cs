using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PacMove : MonoBehaviour{

	float dirX,dirY;
	public float moveSpeed = 5f;
	Rigidbody2D rb;
	bool facingRight = true;
	Vector3 localScale;
	public GameManager GM;
	

    // Start is called before the first frame update
    void Start()
    {
        localScale = transform.localScale;
		rb = GetComponent<Rigidbody2D> ();
    }

    // Update is called once per frame
    void Update()
    {
        dirX =CrossPlatformInputManager.GetAxis ("Horizontal");// * moveSpeed * Time.deltaTime;
		dirY =CrossPlatformInputManager.GetAxis ("Vertical");// * moveSpeed;// * Time.deltaTime;
		transform.position = new Vector2 (transform.position.x + dirX/10, transform.position.y + dirY/5);
    }
	
	void FixedUpdate()
    {
        rb.velocity = new Vector2 (dirX * moveSpeed, 0);
    }
	
	void LateUpdate()
    {
        CheckWhereToFace ();
    }
	
	void CheckWhereToFace ()
    {
        if (dirX > 0)
			facingRight = false;
		else if (dirX < 0)
			facingRight = true;
		
		if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
			localScale.x *= -1;
		
		transform.localScale = localScale;
    }
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.transform.CompareTag("Pacdot"))
		{
			GM.UpdateDots();
		}
		if (other.transform.CompareTag("Red"))
		{
			GM.UpdateLives (-1);
			
			
		}
	}
}
