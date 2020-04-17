using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Galaxy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal void SetPlanetToMass(MassGravity massGravity, Planet planet)
    {
        print("ChangingPlanet");
        massGravity.planet = planet;
    }
}
