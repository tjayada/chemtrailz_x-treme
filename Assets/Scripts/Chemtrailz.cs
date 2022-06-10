using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The script responsible for destroying the instantiated chemtrailz
public class Chemtrailz : MonoBehaviour
{
    // reference to smoke, since the smoke is instantiated when the player flies into the chemtrailz
    [SerializeField] public GameObject _smoke;

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Countdown3());   
    }
    
    // function to destroy a chemtrail 3 seconds after it was instantiated
    private IEnumerator Countdown3() {
        while(true) {
            yield return new WaitForSeconds(3);
            Destroy(this.gameObject);
        }
    }

    // when the player hits a chemtrail, the chemtrail gets destroyed and smoke instantiated
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(_smoke.gameObject, new Vector3(Random.Range(-8f, 8), Random.Range(-4f, 4), 0), Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
