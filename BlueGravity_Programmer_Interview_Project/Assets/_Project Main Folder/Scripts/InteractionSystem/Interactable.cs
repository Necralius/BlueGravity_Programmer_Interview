using UnityEngine;
using UnityEngine.Events;

namespace NekraliusDevelopmentStudio
{
    public class Interactable : MonoBehaviour
    {
        //Code made by Victor Paulo Melo da Silva - Game Developer - GitHub - https://github.com/Necralius
        //Interactable - (0.3)
        //State: Functional
        //This code represents an interaction model class, that holds all the interaction data, state and defaul behavior.

        #region - Interaction Dependecies
        private Animator intcAnim;
        #endregion

        #region - Interaction Data and Actions -
        [Header("Interaction State and Limitations")]
        public bool interactionTriggerSound;
        public bool hasAnimatorInteraction;
        public bool isInteracting;
        private float interactingTimer;

        [Header("Interaction Data and Actions")]
        public UnityEvent interactAction; //-> Unity event that can execute any public methods related to in scene gameobjects.

        public AudioClip interactionClip;
        public Transform interactionTextSpawn;
        public string interactionDetail;
        public float interactTime;
        #endregion

        //============================Methods============================//

        #region - BuiltIn Methods -
        private void Start() //-> Called in the game start
        {
            hasAnimatorInteraction = TryGetComponent(out intcAnim);
            if (hasAnimatorInteraction) intcAnim = GetComponent<Animator>();
        }
        private void Update() //-> Called at every frame update
        {
            //The below statement limmits the interaction system to be interacted in a very short period of time.
            if (isInteracting)
            {
                if (interactingTimer >= interactTime) { isInteracting = false; interactingTimer = 0; }
                else interactingTimer += Time.deltaTime;
            }
        }
        #endregion

        #region - Interaction Behavior -
        public virtual void OnInteract()//This method represents all the defaul interaction behavior of this model.
        {
            if (isInteracting) return;//Detects if is interacting, if it is the method will return without action.

            isInteracting = true;
            if (interactionTriggerSound && !interactionClip.Equals(null)) GameManager.Instance.PlaySound(interactionClip);
            if (hasAnimatorInteraction) intcAnim.SetTrigger("Interact");
            interactAction.Invoke();
        }
        #endregion
    }
}