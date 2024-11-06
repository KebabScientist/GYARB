using System.Collections;
using UnityEngine;

public class Slowdown : MonoBehaviour
{
    public float slowAmount = 10f;
    public float slowDuration = 2f;

    private void OnTriggerEnter(Collider other)
    {
        // Check for CarControlTest2
        CarControlTest2 carController1 = other.GetComponent<CarControlTest2>();
        if (carController1 != null)
        {
            StartCoroutine(Slow(carController1));
            return; 
            Debug.Log("Player collided with Slowdown trap"); return;
        }

        // Check for CarControllerTest1
        CarControlTest1 carController2 = other.GetComponent<CarControlTest1>();
        if (carController2 != null)
        {
            StartCoroutine(Slow(carController2));
            Debug.Log("Player collided with Slowdown trap"); return;
        }
    }

    private IEnumerator Slow(CarControlTest2 carController)
    {
        carController.motorForce -= slowAmount;
        yield return new WaitForSeconds(slowDuration);
        carController.motorForce += slowAmount;
    }

    private IEnumerator Slow(CarControlTest1 carController)
    {
        carController.motorForce -= slowAmount;
        yield return new WaitForSeconds(slowDuration);
        carController.motorForce += slowAmount;
    }
}
