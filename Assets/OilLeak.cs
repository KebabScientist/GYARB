using System.Collections;
using UnityEngine;

public class OilLeak : MonoBehaviour
{
    public float slipDuration = 3f;

    private void OnTriggerEnter(Collider other)
    {
        // Check for CarControlTest2
        CarControlTest2 carController1 = other.GetComponent<CarControlTest2>();
        if (carController1 != null)
        {
            StartCoroutine(Slip(carController1));
            Debug.Log("Player collided with OilLeak trap"); return;
          
        }

        // Check for CarControllerTest1
        CarControlTest1 carController2 = other.GetComponent<CarControlTest1>();
        if (carController2 != null)
        {
            StartCoroutine(Slip(carController2));
            Debug.Log("Player collided with OilLeak trap"); return;
        }
    }

    private IEnumerator Slip(CarControlTest2 carController)
    {
        float originalSteerAngle = carController.maxSteerAngle;
        carController.maxSteerAngle /= 2;
        yield return new WaitForSeconds(slipDuration);
        carController.maxSteerAngle = originalSteerAngle;
    }

    private IEnumerator Slip(CarControlTest1 carController)
    {
        float originalSteerAngle = carController.maxSteerAngle;
        carController.maxSteerAngle /= 2;
        yield return new WaitForSeconds(slipDuration);
        carController.maxSteerAngle = originalSteerAngle;
    }
}
