using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{   
    private void OnEnable()
    {
        Vector3 temp = transform.position;
        transform.rotation = Quaternion.Euler(new Vector3(90f,0f,0f));
        temp.x = temp.x + 0.5f;

        transform.position = temp;
    }
}
