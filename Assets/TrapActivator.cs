using UnityEngine;
using System.Collections.Generic;

public class TrapActivator : MonoBehaviour
{
    public GameObject speedBoostTrapPrefab;
    public GameObject slowdownTrapPrefab;
    public GameObject oilLeakTrapPrefab;

    private Dictionary<string, TrapType> zoneTraps;

    private void Start()
    {
        zoneTraps = new Dictionary<string, TrapType>();
        List<TrapData> traps = GameData.GetPlacedTraps();

        foreach (TrapData trap in traps)
        {
            zoneTraps[trap.zone] = trap.trapType;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            string zoneName = other.gameObject.tag;

            if (zoneTraps.ContainsKey(zoneName))
            {
                ActivateTrap(zoneTraps[zoneName], other.transform.position);
            }
        }
    }

    private void ActivateTrap(TrapType trapType, Vector3 position)
    {
        GameObject trapPrefab = null;

        switch (trapType)
        {
            case TrapType.SpeedBoost:
                trapPrefab = speedBoostTrapPrefab;
                break;
            case TrapType.Slowdown:
                trapPrefab = slowdownTrapPrefab;
                break;
            case TrapType.OilLeak:
                trapPrefab = oilLeakTrapPrefab;
                break;
        }

        if (trapPrefab != null)
        {
            Instantiate(trapPrefab, position, Quaternion.identity);
        }
    }
}
