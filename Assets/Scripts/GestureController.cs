using UnityEngine;
using Edwon.VR.Gesture;
using Edwon.VR;
using System.Collections;

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
                break;
            case "Sauce 3":
            case "Sauce S":
                StartCoroutine(toggleGravity(ObjectFactory.GetNextSauce(handObject.transform), true));
                break;
            case "Cheese":
                StartCoroutine(toggleGravity(ObjectFactory.GetNextCheese(handObject.transform), true));
                break;


            default:
                break;
        }
    }

    IEnumerator toggleGravity(GameObject go, bool on_off)
    {
        yield return new WaitForSeconds(1);
        go.GetComponent<Rigidbody>().useGravity = on_off;
    }

    private void OnGestureRejected(string error, string gestureName = null, double confidence = 0)
    {
        Debug.Log("You drew something I don't recognize");
    }
}
