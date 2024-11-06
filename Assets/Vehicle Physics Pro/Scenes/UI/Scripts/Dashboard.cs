using UnityEngine;
using UnityEngine.UI;
using System;

public class Dashboard : MonoBehaviour
{
    public GameObject vehicleObject; // Assign your specific vehicle GameObject here
    public float maxSpeed = 200.0f;  // Maximum speed for the speedometer
    public float maxRpm = 8000.0f;   // Maximum RPM for the RPM gauge

    [Header("Needles")]
    public Needle speedNeedle = new Needle();
    public Needle rpmNeedle = new Needle();

    [Header("Dashboard elements")]
    public GameObject stalledSignal;
    public GameObject handbrakeSignal;
    public GameObject warningSignal;
    public GameObject retarderSignal;
    public GameObject axleDiffLockSignal;
    public GameObject centerDiffLockSignal;
    public GameObject fullDiffLockSignal;
    public GameObject singleAxleDriveSignal;
    public GameObject singleAxleDiffLockSignal;

    [Header("UI labels")]
    public Text gearLabel;
    public Text speedMphLabel;

    [Serializable]
    public class Needle
    {
        public Transform needle;
        public float minValue = 0.0f;
        public float maxValue = 200.0f;
        public float angleAtMinValue = 135.0f;
        public float angleAtMaxValue = -135.0f;

        public void SetValue(float value)
        {
            if (needle == null) return;

            float x = Mathf.InverseLerp(minValue, maxValue, value);
            float angle = Mathf.Lerp(angleAtMinValue, angleAtMaxValue, x);

            needle.localRotation = Quaternion.Euler(0, 0, angle);
        }
    }

    void Update()
    {
        if (vehicleObject == null) return;

        // Assuming vehicleObject has a script with speed and rpm properties
        VehicleData vehicleData = vehicleObject.GetComponent<VehicleData>();
        if (vehicleData != null)
        {
            float speedMs = vehicleData.Speed;
            float engineRpm = vehicleData.EngineRpm;

            speedNeedle.SetValue(speedMs * 3.6f);  // Convert m/s to km/h
            rpmNeedle.SetValue(engineRpm);

            // Update speed MPH label
            if (speedMphLabel != null)
                speedMphLabel.text = (speedMs * 2.237f).ToString("0") + "\nmph";

            // Update gear label
            if (gearLabel != null)
                gearLabel.text = vehicleData.CurrentGear;
        }
    }

    void SetEnabled(GameObject go, bool active)
    {
        if (go != null) go.SetActive(active);
    }
}

// Example VehicleData script that the vehicleObject might have
public class VehicleData : MonoBehaviour
{
    public float Speed;      // Speed in meters per second
    public float EngineRpm;  // Engine RPM
    public string CurrentGear; // Current gear as a string
}
