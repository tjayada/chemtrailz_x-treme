using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// script for movinf the nitro fuel object
public class Objects : MonoBehaviour
{
    // set speed of nitro to 8
    private float _speed = 8f;

    // reference to turbo plane, since collecting nitro will result in turbo
    [SerializeField] private GameObject _turboPlane;
    
    // Update is called once per frame
    // move nitro object and destroy when not collected
    void Update()
    {
        // move nitro with defined speed
        transform.Translate(Vector3.down * Time.deltaTime * _speed);

        // destroy nitro when not collected, so when "fallen" out of screen
        if (transform.position.y < -15f)
        {
            Destroy(this.gameObject);
        }   
    }
    
    // when nitro collected, then instantiate turbo plane
    private void OnTriggerEnter2D(Collider2D other)
    {
        // only care about collision with player
        if (other.CompareTag("Player"))
        {
            // instantiate turbo plane   
            Instantiate(_turboPlane.gameObject, other.transform.position , Quaternion.identity);
            // call spawn manager function, so the counted miles will be counted "faster" now (with turbo on -> more miles)
            GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<Spawn_manager>().turboOn();
            // destroy old plane and the nitro
            Destroy(this.gameObject);
            Destroy(other.gameObject);
            
        }
    }
}
