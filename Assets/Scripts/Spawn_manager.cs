using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// script responsible for organizing enemy spawns and keeping track of:
// miles, turbo on/off, players death
public class Spawn_manager : MonoBehaviour
{
    
    // References to objects that get spawned
    // "fast" enemy
    [SerializeField]
    private GameObject _enemyPrefab;
    
    // slow enemy with chemtrails
    [SerializeField]
    private GameObject _enemyChemPrefab;
    
    // nitro for turbo
    [SerializeField]
    private GameObject _nitro;
    
    // gas mask to get rid of smoke
    [SerializeField]
    private GameObject _gasMask;

    // ui manager for displaying the miles
    [SerializeField] private UI_manager _uiManager;
    
    // VARIABLES
    private bool _alive = true;

    private float _rnd = 0;

    public int _miles = 0;

    private bool _turbo = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FlyMiles());
        StartCoroutine(SpawnSystem());
    }
    
    // spawn enemy and objects
    IEnumerator SpawnSystem()
    {
        // Spawning only if player is alive
        while (_alive)
        {
            // spawn fast and slow enemy
            Instantiate(_enemyPrefab, new Vector3(Random.Range(-10f, 10f), 20f, 0), Quaternion.identity);
            Instantiate(_enemyChemPrefab, new Vector3(Random.Range(-10f, 10f), 20f, 0), Quaternion.identity);

            // with some random chance spawn a nitro
            _rnd = Random.Range(0, 7);
            if (_rnd == 5f)
            {
                Instantiate(_nitro, new Vector3(Random.Range(-10f, 10f), 20f, 0), Quaternion.identity);
            }

            // with some random chance spawn a gas mask
            if (_rnd == 2f ||_rnd == 4f || _rnd == 6f)
            {
                Instantiate(_gasMask, new Vector3(Random.Range(-10f, 10f), 20f, 0), Quaternion.identity);
            }

            // wait 5 seconds before the "next round" of spawning stuff
            yield return new WaitForSeconds(5f);
        }

        yield return null;
    }
    
    // if enemy destroys player, then alive = false and while loop of spawning stops
    public void onPlayerDeath()
    {
        _alive = false;
    }
    
    // turn turbo on, for faster mile counting
    public void turboOn()
    {
        _turbo = true;
    }
    
    // turn turbo of, back to normal mile counting
    public void turboOff()
    {
        _turbo = false;
    }

    // counting miles in spawn manager, since player could have
    // collected nitro, thus destroying and instantiating the "turbo" plane
    // and with that the miles would have been gone
    IEnumerator FlyMiles()
    {
        // only count miles when player is alive (stop when dead)
        while (_alive)
        {
            // check if turbo is on or not and count miles depending on that
            if (_turbo == false)
            {
                _miles += 10;
                _uiManager.updateMiles(_miles);
                yield return new WaitForSeconds(1f);
            }

            if (_turbo == true)
            {
                _miles += 25;
                _uiManager.updateMiles(_miles);
                yield return new WaitForSeconds(1f);
            }
            
        }
        
        yield return null;
    }
    
}
