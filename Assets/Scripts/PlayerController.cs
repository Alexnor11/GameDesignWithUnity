using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidBody;

    [SerializeField, Tooltip("Какое ускорение прикладывается к данному объекту")]
    private float _movementAcceleration = 2;

    [SerializeField, Tooltip("Максимальная скорость этого объекта")]
    private float _movementVelocityMax = 2;

    [SerializeField, Tooltip("Замeдление при отсутствии сигнала направления")]
    private float _movementFriction = 0.05f;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        Vector3 curSpeed = _rigidBody.velocity;

        if (Input.GetKey(KeyCode.RightArrow))
            curSpeed.x += (_movementAcceleration * Time.deltaTime);
        
        if (Input.GetKey(KeyCode.LeftArrow))
            curSpeed.x -= (_movementAcceleration * Time.deltaTime);

        if (Input.GetKey(KeyCode.UpArrow))
                curSpeed.z += (_movementAcceleration * Time.deltaTime);

        if (Input.GetKey(KeyCode.DownArrow))
            curSpeed.z -= (_movementAcceleration * Time.deltaTime);

        if(Input.GetKey(KeyCode.RightArrow) == Input.GetKey(KeyCode.LeftArrow))
        {
            curSpeed.x -= _movementFriction * curSpeed.x;
        }

        if (Input.GetKey(KeyCode.UpArrow) == Input.GetKey(KeyCode.DownArrow))
        {
            curSpeed.z -= _movementFriction * curSpeed.z;
        }


        curSpeed.x = Mathf.Clamp(curSpeed.x, _movementVelocityMax * -1, _movementVelocityMax);
        curSpeed.z = Mathf.Clamp(curSpeed.z, _movementVelocityMax * -1, _movementVelocityMax);

        _rigidBody.velocity = curSpeed;
    }
}
