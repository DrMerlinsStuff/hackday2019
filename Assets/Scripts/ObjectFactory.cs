using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class ObjectFactory
{
    static private int doughCount;
    static private int doughIndex;
    static private List<GameObject> doughs;

    public static void CreateDoughs(GameObject dough, int count = 10)
    {
        doughs = Enumerable.Range(1, count).Select(x => GameObject.Instantiate(dough, new Vector3(50,0,0),Quaternion.identity)).ToList();
        doughCount = count;
        doughIndex = 0;
    }

    public static GameObject GetNextDough(Transform parent)
    {
        var dough = doughs[doughIndex];
        dough.transform.position = parent.position;
        dough.transform.rotation = Quaternion.identity;
        doughIndex = (doughIndex + 1) % doughCount;
        Debug.Log("Dough index: " + doughIndex + " Dough Count: " + doughCount);
        return dough;
    }
}
