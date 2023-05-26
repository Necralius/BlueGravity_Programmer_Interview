using System.Collections.Generic;
using UnityEngine;

namespace NekraliusDevelopmentStudio
{
    public class PlayerMovment : MonoBehaviour
    {
        //Code made by Victor Paulo Melo da Silva - Game Developer - GitHub - https://github.com/Necralius
        //PlayerMovment - (0.3)
        //State: Functional
        //This code represents (Code functionality or code meaning)

        #region - Player Dependencies -
        public InputManager InputManager => InputManager.Instance;
        private Animator playerAnim => GetComponent<Animator>();
        private Rigidbody2D playerRb => GetComponent<Rigidbody2D>();
        #endregion

        #region - Player State -
        [Header("Player State")]
        public bool isWalking = false;
        #endregion

        #region - Player Settings -
        [Range(1, 100)] public float playerSpeed = 10f;
        [Range(1, 100)] public float forceDamping = 1.2f;
        #endregion

        #region - Player Movment Data -
        private Vector2 forceToApply;
        #endregion

        #region - Interaction Data -
        [Header("Interaction Data")]
        public Interactable interactableInArea;
        #endregion

        #region - Animation System -
        public List<Animator> allAnimators;
        #endregion

        #region - Footstep System -
        public float timeBetweenSteps = 1f;
        private float footstepsTimer;
        public AudioClip footstepSound;
        #endregion

        //============================Methods============================//

        #region - BuiltIn Methods -
        private void Start() //-> Called in the game start
        {
            //In the start the code get all the needed information, and set all needed data to initialize all the player systems.
            allAnimators.AddRange(GetComponentsInChildren<Animator>());
            foreach(var animator in allAnimators)
            {
                if (animator.Equals(playerAnim)) continue;
                animator.gameObject.SetActive(false);
            }
        }
        private void Update() //-> Executed every frame
        {
            Move();
            UpdateActions();
        }
        #endregion

        #region - Input and State Update -
        private void UpdateActions()
        {
            //This method set all the player general and animation states based on his inputs.
            isWalking = InputManager.moveVector != Vector2.zero;

            if (InputManager.interacted && !interactableInArea.Equals(null)) interactableInArea.OnInteract();

            playerAnim.SetFloat("Horizontal", InputManager.moveVector.x);
            playerAnim.SetFloat("Vertical", InputManager.moveVector.y);
            playerAnim.SetBool("isWalking", isWalking);

            UpdateAllAnimations();

            //The below statements manage the walk sounds, using footstep intervals.
            if (isWalking)
            {
                if (footstepsTimer >= timeBetweenSteps)
                {
                    GameManager.Instance.PlayFootstepSound(footstepSound);
                    footstepsTimer = 0;
                }
                else footstepsTimer += Time.deltaTime;

            }
        }
        #endregion

        #region - Movment Calculation and Apply -
        private void Move() //-> This method manage all the player movment.
        {
            //The below statements represents the input detection provided by the Input Manager class.
            Vector2 playerInput = new Vector2(InputManager.moveVector.x, InputManager.moveVector.y).normalized;

            Vector2 moveForce = playerInput * playerSpeed;
            moveForce += forceToApply;
            forceToApply /= forceDamping;

            //The below statement sets the player velocity vector to zero if it is very near to stop.
            if (Mathf.Abs(forceToApply.x) <= 0.01f && Mathf.Abs(forceToApply.y) <= 0.01f) forceToApply = Vector2.zero;


            //In the code final statement the player movement is finaly applyied.
            playerRb.velocity = moveForce;
        }
        #endregion

        #region - Collision System -
        private void OnTriggerEnter2D(Collider2D collision) //This method detects if the player has entered in a trigger collider.
        {
            if (collision.transform.CompareTag("Interactable"))//This statements activate the interactable, update his
            {
                Interactable interactionAsset = collision.GetComponent<Interactable>();

                InteractionView.Instance.SetUpInteraction(interactionAsset);
                InteractionView.Instance.UpdateUI_State(true);
                interactableInArea = interactionAsset;
            }
        }
        private void OnTriggerExit2D(Collider2D collision) //This method detects if the player has exit of an trigger collider.
        {
            if (collision.transform.CompareTag("Interactable"))//This statements remove the current interactable of the player and updates the interaction system UI;
            {
                InteractionView.Instance.UpdateUI_State(false);
                interactableInArea = null;            
            }
        }
        #endregion

        #region - Animation Behavior -
        private void UpdateAllAnimations()
        {
            foreach (Animator anim in allAnimators)
            {
                if (anim.isActiveAndEnabled)
                {
                    anim.SetFloat("Horizontal", InputManager.moveVector.x);
                    anim.SetFloat("Vertical", InputManager.moveVector.y);
                    anim.SetBool("isWalking", isWalking);
                }
            }
        }     
        #endregion
    }
}