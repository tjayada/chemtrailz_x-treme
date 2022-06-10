using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// script for moving and destroying turbo plane
public class turbo_plane_behave : MonoBehaviour
{
    // set speed higher than normal plane
    private float _speed = 20f;
    
    // reference to normal plane
    [SerializeField]
    private Rigidbody2D RB;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Countdown10());
    }

    // Update is called once per frame
    void Update()
    {
        // MOVEMENT
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * Time.deltaTime * _speed * horizontalInput); 
        transform.Translate(Vector3.up * Time.deltaTime * _speed * verticalInput);
    }
    
    // destroy turbo plane after 10 seconds and instantiote normal plane again
    private IEnumerator Countdown10() {
        while(true) {
            yield return new WaitForSeconds(10); //wait 10 seconds
            Instantiate(RB.gameObject, transform.position , Quaternion.identity); // spawn normal plane
            GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<Spawn_manager>().turboOff(); // tell spawn manager to count slower again
            Destroy(this.gameObject); // destroy the turbo plane
        }
    }
}
