using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// script for making the gas mask move and remove smoke if collected
public class gasMask_behave : MonoBehaviour
{
    // set "falling" speed of gas mask to 8
    private float _speed = 8f;
    
    // Update is called once per frame
    // move gas mask and destroy when not collected
    void Update()
    {
        // move gas mask at "falling" speed
        transform.Translate(Vector3.down * Time.deltaTime * _speed);

        // destroy gas mask when not collected, so when "fallen" below screen
        if (transform.position.y < -15f)
        {
            Destroy(this.gameObject);
        }   
    }
    
    // when gas mask is collected, then remove a smoke
    private void OnTriggerEnter2D(Collider2D other)
    {
        // only care about collision with player
        if (other.CompareTag("Player"))
        {
            // check if there exists a smoke that can be removed
            if (GameObject.FindGameObjectWithTag("Smoke") != null)
            {
                // remove a smoke
                GameObject.FindGameObjectWithTag("Smoke").GetComponent<smoke_behave>().destroySmoke();
            }
            
            // destroy gas mask
            Destroy(this.gameObject);
            
        }
    }
}
