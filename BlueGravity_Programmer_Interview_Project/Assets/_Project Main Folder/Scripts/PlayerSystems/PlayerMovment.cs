using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace NekraliusDevelopmentStudio
{
    public class PlayerMovment : MonoBehaviour
    {
        //Code made by Victor Paulo Melo da Silva - Game Developer - GitHub - https://github.com/Necralius
        //PlayerMovment - (0.1)
        //State: Functional - (Needs Refactoring, Needs Coments, Needs Improvement)
        //This code represents (Code functionality or code meaning)

        public InputManager InputManager => InputManager.Instance;

        private Rigidbody2D playerRb => GetComponent<Rigidbody2D>();

        [Range(1, 100)] public float playerSpeed = 10f;
        [Range(1, 100)] public float forceDamping = 1.2f;

        private Vector2 forceToApply;

        public Interactable interactableInArea;

        private void Update()
        {
            Move();
            GeneralInputInteractions();
        }
        private void GeneralInputInteractions()
        {
            if (InputManager.interacted && !interactableInArea.Equals(null)) interactableInArea.OnInteract();
        }
        private void Move()
        {
            //The below statements represents the input detection provided by the Input Manager Class.
            Vector2 playerInput = new Vector2(InputManager.moveVector.x, InputManager.moveVector.y).normalized;

            Vector2 moveForce = playerInput * playerSpeed;
            moveForce += forceToApply;
            forceToApply /= forceDamping;

            //The below statement sets the player velocity vector to zero if it is very near to stop.
            if (Mathf.Abs(forceToApply.x) <= 0.01f && Mathf.Abs(forceToApply.y) <= 0.01f) forceToApply = Vector2.zero;

            playerRb.velocity = moveForce;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.transform.CompareTag("Interactable"))
            {
                Interactable interactionAsset = collision.GetComponent<Interactable>();

                InteractionController.Instance.SetUpKey(interactionAsset);
                InteractionController.Instance.UpdateUI_State(true);
                interactableInArea = interactionAsset;
            }
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.transform.CompareTag("Interactable")) InteractionController.Instance.UpdateUI_State(false);
        }
    }
}