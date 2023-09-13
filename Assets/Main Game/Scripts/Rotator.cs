using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float PlanetSpeedDivider;
    public float PlanetOrbitalSpeedDivider;

    [Serializable]
    class Planet
    {
        public Transform transform;
        public float rotationSpeed = 1;
    }
    [SerializeField] Transform[] parents;
    [SerializeField] Planet[] planetCenters;
    [SerializeField] Planet[] planets;
    [SerializeField] Planet[] TurnX;
    [SerializeField] Planet[] TurnY;

    [EButton]
    void AssignArrays()
    {
        for (int i = 0; i < parents.Length; i++)
        {
            planetCenters[i].transform = parents[i];
            planetCenters[i].rotationSpeed = 10;
            planets[i].transform = parents[i].GetChild(0);
            planets[i].rotationSpeed = 10;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        foreach(var planet in planetCenters)
            planet.transform.Rotate(0, 0, planet.rotationSpeed/PlanetOrbitalSpeedDivider);
        foreach (var planet in planets)
            planet.transform.Rotate(planet.rotationSpeed/PlanetSpeedDivider, 0, 0);

        foreach (var i in TurnX)
            i.transform.Rotate(i.rotationSpeed, 0, 0);
        foreach (var i in TurnY)
            i.transform.Rotate(0,i.rotationSpeed, 0);
    }
}
