using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// script for the behaviour of the "fast" plane
public class enemy_plane_behave : MonoBehaviour
{
    // set speed of the "fast" plane to 10
    // start with 0 miles 
    private float _speed = 10f;
    private float _miles = 0;

    // reference to the explosion, if the player hits this enemy
    [SerializeField] private GameObject explosion;
    
    void Update()
    {
        // get the miles from the spawn manager
        _miles = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<Spawn_manager>()._miles;

        // if the player flew long, the enemy will be faster
        // --> game increasingly more difficult 
        if (_miles > 1000)
        {
            _speed = 11f;
        }
        
        if (_miles > 2000)
        {
            _speed = 12f;
        }
        
        // move enemy "down" the screen at the defined speed
        transform.Translate(Vector3.down * Time.deltaTime * _speed);

        // if the enemy is out of the screen (below it), then destroy the enemy
        if (transform.position.y < -15f)
        {
            Destroy(this.gameObject);
        }
        
    }
    
    // if this enemy hits the player, then destroy the player, this enemy and all the smokes
    // also call a function that stops new enemies from spawning 
    private void OnTriggerEnter2D(Collider2D other)
    {
        // only care about collision with player
        if (other.CompareTag("Player"))
        {
            // make explosion
            Instantiate(explosion.gameObject, transform.position , Quaternion.identity);
            // call function to stop spawning enemies
            GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<Spawn_manager>().onPlayerDeath();
            // call function to display the buttons to either play again or go back to the menu
            GameObject.FindGameObjectWithTag("EndButton").GetComponent<EndButton_script>().ShowButtons();
            // destroy enemy and player
            Destroy(this.gameObject);
            Destroy(other.gameObject);
            
            // destroy all existing smokes 
            GameObject[] All_smokes = GameObject.FindGameObjectsWithTag("Smoke");
            foreach(GameObject smokes in All_smokes)
                Destroy(smokes);
        }
    }
}