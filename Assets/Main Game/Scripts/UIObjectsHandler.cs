using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class UIObjectsHandler : MonoBehaviour
{
    [Header("Planet and orbital speed divider")]
    [SerializeField] Rotator rotator;

    [Header("Star Intensity")]
    [SerializeField] Volume SkyVolume;

    [Tooltip("Minimum value for exposure of HDRI sky volume")]
    [SerializeField] float SkyExposureMin;
    [Tooltip("Max value for exposure of HDRI sky volume")]
    [SerializeField] float SkyExposureMax;

    HDRISky hDRISky;
    private void Start()
    {
        //assign variables
        if (!SkyVolume.profile.TryGet(out hDRISky))
            Debug.LogError("HDRISky not found");

    }

    public void OnStarIntensityScrollBarChanged(float Value)
    {
        Value = (SkyExposureMax - SkyExposureMin) * Value + SkyExposureMin;
        hDRISky.exposure.value = Value;
    }


    public void OnPlanetSpeedDividerInputFieldValueChanged(string value)
    {
        if (float.TryParse(value, out float valueFloat))
            rotator.PlanetSpeedDivider = valueFloat;
        else
            Debug.LogError("OnPlanetSpeedDividerInputFieldValueChanged TryParse failed");
    }
    public void OnPlanetOrbitSpeedDividerInputFieldValueChanged(string value)
    {
        if (float.TryParse(value, out float valueFloat))
            rotator.PlanetOrbitalSpeedDivider = valueFloat;
        else
            Debug.LogError("OnPlanetOrbitSpeedDividerInputFieldValueChanged TryParse failed");
    }
}
