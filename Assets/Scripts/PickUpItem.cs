using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    [SerializeField, Tooltip("Скорость с которой вращается объект")]
    private float _rotationSpeed = 5;

    public static int s_objectsCollected = 0;  

 
        void Update()
    {
        Vector3 newRotation = transform.eulerAngles;
        newRotation.y += (_rotationSpeed * Time.deltaTime);
        transform.eulerAngles = newRotation;
    }

    public void onPickedUp(GameObject whoPickedUp)
    {
        s_objectsCollected++;
        Debug.Log(s_objectsCollected + " items picked up.");
        Destroy(gameObject);
    }
}
