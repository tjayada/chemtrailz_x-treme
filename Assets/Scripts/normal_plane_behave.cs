using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// script for controlling the players normal plane
public class normal_plane_behave : MonoBehaviour
{
    // set speed of normal plane
    private float _speed = 10f;
    
    // set movements limit of player to boundary of game display
    private float x_lim = 9f;
    private float y_lim = 5f;

    // Update is called once per frame
    // check if player is allowed to move and move if so
    void Update()
    {
        // check if allowed to move
        if (transform.position.x > -x_lim && transform.position.x < x_lim)
        {
            if (transform.position.y > -y_lim && transform.position.y < y_lim)
            {
                // MOVEMENT
                float horizontalInput = Input.GetAxis("Horizontal");
                float verticalInput = Input.GetAxis("Vertical");
                transform.Translate(Vector3.right * Time.deltaTime * _speed * horizontalInput); 
                transform.Translate(Vector3.up * Time.deltaTime * _speed * verticalInput);
            }
        }

        // if player gets outside the limit through fast movements and velocity
        // then set the player slightly back inside the allowed boundary
        // otherwise player would be stuck "outside" and was not allowed to move anymore
        if (transform.position.x > x_lim)
        {
            transform.position = new Vector3(x_lim-0.1f,transform.position.y, transform.position.z);
        }
        
        if (transform.position.x < -x_lim)
        {
            transform.position = new Vector3(-x_lim+0.1f, transform.position.y, transform.position.z);
        }
        
        if (transform.position.y > y_lim)
        {
            transform.position = new Vector3(transform.position.x, y_lim-0.1f, transform.position.z);
        }
        
        if (transform.position.y < -y_lim)
        {
            transform.position = new Vector3(transform.position.x, -y_lim+0.1f, transform.position.z);
        }
    }
}
