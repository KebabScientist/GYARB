using System.Collections;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    public float boostAmount = 20f;
    public float boostDuration = 2f;

    private void OnTriggerEnter(Collider other)
    {
        // Check for CarControlTest2
        CarControlTest2 carController1 = other.GetComponent<CarControlTest2>();
        if (carController1 != null)
        {
            StartCoroutine(Boost(carController1));
            return;
        }

        // Check for CarControllerTest1
        CarControlTest1 carController2 = other.GetComponent<CarControlTest1>();
        if (carController2 != null)
        {
            StartCoroutine(Boost(carController2));
        }
    }

    private IEnumerator Boost(CarControlTest2 carController)
    {
        carController.motorForce += boostAmount;
        yield return new WaitForSeconds(boostDuration);
        carController.motorForce -= boostAmount;
    }

    private IEnumerator Boost(CarControlTest1 carController)
    {
        carController.motorForce += boostAmount;
        yield return new WaitForSeconds(boostDuration);
        carController.motorForce -= boostAmount;
    }
}
