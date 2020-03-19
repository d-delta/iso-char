using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatRangeTrigger : MonoBehaviour
{
    // Start is called before the first frame update

    public List <GameObject> enemiesInRange = new List <GameObject> ();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "EN" && transform.gameObject.tag == "playerRange"){
            enemiesInRange.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "EN" && transform.gameObject.tag == "playerRange"){
            enemiesInRange.Remove(other.gameObject);
        }
    }
}
