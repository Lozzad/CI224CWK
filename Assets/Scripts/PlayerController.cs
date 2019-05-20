using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int speed = 10;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    Rigidbody rb;
    Camera cam;

    void Awake() {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update() {
        //snappier jump
        if (rb.velocity.y < 0) {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        } else if (rb.velocity.y > 0 && !Input.GetButton("Jump")) {
			rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        } 
        
        Move();

        if (Input.GetButtonDown("Jump")) {
            Jump();
        }
    }

    void Move() {
		Vector3 rawMovement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		Vector3 actualMovement = Quaternion.Euler(0, cam.transform.eulerAngles.y, 0) * rawMovement;
		transform.position += actualMovement * speed * Time.deltaTime;
    }

    void Jump() {
        rb.AddForce(Vector3.up*10, ForceMode.Impulse);
    }
}
