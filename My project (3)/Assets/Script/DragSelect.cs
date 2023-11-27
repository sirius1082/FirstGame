using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extention
{
    public static IEnumerator ChangeWithDelay<T>(this T origin , T changeValue, float delay , Action<T> makeResult)
    {
        yield return new WaitForSeconds(delay);
        makeResult(changeValue);
        Debug.Log("Change Completed");
    }


    public static IEnumerator DelayAction<T>(this MonoBehaviour monoBehaviour , T currentValue , T newValue , float delay , Action<T> action)
    {
        yield return new WaitForSeconds(delay);
        action(newValue);
        Debug.Log("Action Completed");
    }

}

public class DragSelect : MonoBehaviour
{

    public bool isKind = false;

    public bool isTest = false;
    private void Start()
    {
        ChangeValueTest();
        TestRefValue(isTest);
    }

    
    

    public void TestRefValue(bool isKind)
    {
        RefTest(isKind , value => isTest = true) ;


    }
    public void RefTest(bool isCheck, Action<bool> change)
    {
        StartCoroutine(isCheck.ChangeWithDelay<bool>(isCheck, 3f, change));
    }
    public void Test(bool isCheck , Action<bool> change)
    {
        StartCoroutine(isCheck.ChangeWithDelay<bool>(isCheck,3f, change));
    }
    public void ChangeValueTest()
    {
        Test(isKind, value => isKind = true);
    }
   


}


