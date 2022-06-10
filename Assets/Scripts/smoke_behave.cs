using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// simple script to destroy the smoke (when gas mask is collected)
public class smoke_behave : MonoBehaviour
{
    // destroy smoke
    public void destroySmoke()
    {
        Destroy(this.gameObject);
    }
}
