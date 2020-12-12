using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    GameObject player;
    Rigidbody playerRigidBody;
    bool isFloating = false;
    // Start is called before the first frame update
    void Start()
    {
        player = this.gameObject;
        playerRigidBody = player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        playerRigidBody.transform.Translate(Input.GetAxis("Horizontal") / 10, 0, Input.GetAxis("Vertical") / 10);
        if (Input.GetKey("space") && isFloating == false)
        {
            playerRigidBody.AddForce(0, 500, 0);
            isFloating = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player") { }
        {
            isFloating = false;
        }
    }
}
