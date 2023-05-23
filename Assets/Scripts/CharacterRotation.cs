using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;

public class CharacterRotation : MonoBehaviour
{
    [SerializeField] private Vector2 mouseInput;
    [SerializeField] private float mouseSens = 100f;

    private Vector2 turn;

    // Update is called once per frame
    void Update()
    {
        transform.localRotation = Quaternion.Euler(0, turn.x/100 * mouseSens, 0);
    }

    void OnLook(InputValue value)
    {
        mouseInput = value.Get<Vector2>();

        turn += mouseInput;
    }
}
