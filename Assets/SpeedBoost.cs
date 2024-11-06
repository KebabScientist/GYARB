using System.Collections;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    public float boostAmount = 20f;
    public float boostDuration = 2f;

    private void OnTriggerEnter(Collider other)
    {
        CarControlTest2 carController1 = other.GetComponent<CarControlTest2>();
        if (carController1 != null)
        {
            StartCoroutine(Boost(carController1));
            Debug.Log("Player collided with SpeedBoost trap");
            return;
        }

        CarControlTest1 carController2 = other.GetComponent<CarControlTest1>();
        if (carController2 != null)
        {
            StartCoroutine(Boost(carController2));
            Debug.Log("Player collided with SpeedBoost trap");
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
