using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Composites;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UI;

namespace NekraliusDevelopmentStudio
{
    public class InputManager : MonoBehaviour
    {
        //Code made by Victor Paulo Melo da Silva - Game Developer - GitHub - https://github.com/Necralius
        //InputManager - (0.1)
        //State: - (Needs Refactoring, Needs Coments, Needs Improvement)
        //This code represents (Code functionality or code meaning)

        #region - Singleton Pattern -
        public static InputManager Instance;
        private void Awake() => Instance = this;
        #endregion

        private PlayerInput playerInput => GetComponent<PlayerInput>();

        public Vector2 moveVector;
        public bool interacted;

        private InputActionMap currentMap;
        private InputAction moveAction;
        private InputAction interactAction;

        private void Start()
        {
            currentMap = playerInput.currentActionMap;

            moveAction = currentMap.FindAction("MoveAction");
            interactAction = currentMap.FindAction("Interact");
        }
        private void Update()
        {
            moveVector = moveAction.ReadValue<Vector2>().normalized;
            interacted = interactAction.triggered;
        }
    }
}