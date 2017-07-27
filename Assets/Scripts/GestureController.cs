using UnityEngine;
using Edwon.VR.Gesture;
using Edwon.VR;

public class GestureController : MonoBehaviour
{
    public GameObject dough;

    void OnEnable()
    {
        GestureRecognizer.GestureDetectedEvent += OnGestureDetected;
        GestureRecognizer.GestureRejectedEvent += OnGestureRejected;
    }

    void OnDisable()
    {
        GestureRecognizer.GestureDetectedEvent -= OnGestureDetected;
        GestureRecognizer.GestureRejectedEvent -= OnGestureRejected;
    }

    private void OnGestureDetected(string gestureName, double confidence, Handedness hand, bool isDouble = false)
    {
        switch(gestureName)
        {
            case "Dough Top Left":
            case "Dough Top Right":
            case "Dough Bottom Left":
            case "Dough Bottom Right":
                Instantiate(dough, transform.position, transform.rotation);
                Debug.Log("Building Dough");
                break;
            
            default:
                break;
        }
    }

    private void OnGestureRejected(string error, string gestureName = null, double confidence = 0)
    {
        
    }
}
