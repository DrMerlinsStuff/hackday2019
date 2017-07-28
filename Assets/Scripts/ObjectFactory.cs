using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class ObjectFactory
{
    static private int doughCount;
    static private int doughIndex;
    static private int sauceCount;
    static private int sauceIndex;
    static private int cheeseIndex;
    static private int cheeseCount;
    static private List<GameObject> doughs;
    static private List<GameObject> sauces;
    static private List<GameObject> cheeses;

    public static void CreateDoughs(GameObject dough, int count = 10)
    {
        doughs = Enumerable.Range(1, count).Select(x => GameObject.Instantiate(dough, new Vector3(50,0,0),Quaternion.identity)).ToList();
        doughCount = count;
        doughIndex = 0;
    }

    public static void CreateSauces(GameObject sauce, int count = 10)
    {
        sauces = Enumerable.Range(1, count).Select(x => GameObject.Instantiate(sauce, new Vector3(50, 0, 0), Quaternion.identity)).ToList();
        sauceCount = count;
        sauceIndex = 0;
    }

    public static void CreateCheeses(GameObject cheese, int count = 20)
    {
        cheeses = Enumerable.Range(1, count).Select(x => GameObject.Instantiate(cheese, new Vector3(50, 0, 0), Quaternion.identity)).ToList();
        cheeseCount = count;
        cheeseIndex = 0;
    }

    public static GameObject GetNextDough(Transform parent)
    {
        var dough = doughs[doughIndex];
        dough.transform.position = parent.position;
        dough.transform.rotation = Quaternion.identity;
        doughIndex = (doughIndex + 1) % doughCount;
        return dough;
    }

    public static GameObject GetNextSauce(Transform parent)
    {
        var sauce = sauces[sauceIndex];
        sauce.transform.position = parent.position;
        sauce.transform.rotation = parent.rotation;

        sauce.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        sauceIndex = (sauceIndex + 1) % sauceCount;
        return sauce;
    }

    public static GameObject GetNextCheese(Transform parent)
    {
        var cheese = cheeses[cheeseIndex];
        cheese.transform.position = parent.position;
        cheese.transform.rotation = parent.rotation;

        cheese.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        cheeseIndex = (cheeseIndex + 1) % cheeseCount;
        return cheese;
    }
}
