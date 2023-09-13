using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetLocater : MonoBehaviour
{
    [SerializeField] float Margin;
    [SerializeField] float Size;
    [SerializeField] float SunScale;

    [Tooltip("You should add planets in the right order")]
    [SerializeField] Transform[] Planets;
    [SerializeField] Transform sun;

    [EButton("Locate and Resize planets")]
    void Locate()
    {
        for (int i = 0; i < Planets.Length; i++)
        {
            Planets[i].position = new Vector3((SunScale / 2) + (Margin * (i + 1)), 0, 0);

            Planets[i].localScale = Vector3.one * Size;
        }
        
    }
}
