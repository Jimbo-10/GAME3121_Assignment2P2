using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;
using Unity.Mathematics;


public class RotateCameraX : MonoBehaviour
{
    private float speed = 100;
    public GameObject player;

    [SerializeField]
    InputActionAsset inputAsset;

    InputAction lookAction;

    void Start()
    {
        lookAction = inputAsset.FindAction("Look");
    }
    // Update is called once per frame
    void Update()
    {
        //float horizontalInput = Input.GetAxis("Horizontal");
        float2 look = lookAction.ReadValue<Vector2>();
        
        float horizontal = look.x;

        transform.Rotate(Vector3.up, horizontal * speed * Time.deltaTime);

        transform.position = player.transform.position; // Move focal point with player

    }
}
