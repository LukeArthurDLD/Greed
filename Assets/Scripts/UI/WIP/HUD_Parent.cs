using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD_Parent : MonoBehaviour
{
    public GameObject reticule;
    public GameObject hitmarkers;

    // Start is called before the first frame update
    void Start()
    {
        hitmarkers.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            hitmarkers.SetActive(true);
            reticule.GetComponent<Animation>().Play();
            hitmarkers.GetComponent<Animation>().Play();
        }
    }
}
