using UnityEngine;
using Edwon.VR.Gesture;
using Edwon.VR;

public class GestureController : MonoBehaviour
{

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
        var handObject = hand == Handedness.Left ? SceneObjects.LeftController : SceneObjects.RightController;

        switch(gestureName)
        {
            case "Dough Top Left":
            case "Dough Top Right":
            case "Dough Bottom Left":
            case "Dough Bottom Right":
                ObjectFactory.GetNextDough(handObject.transform);
                Debug.Log("Building Dough");
                break;
            
            default:
                Debug.Log("Recognized something else");
                break;
        }
    }

    private void OnGestureRejected(string error, string gestureName = null, double confidence = 0)
    {
        Debug.Log("You aint no dough");
    }
}
