using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

namespace NekraliusDevelopmentStudio
{
    public class Interactable : MonoBehaviour
    {
        //Code made by Victor Paulo Melo da Silva - Game Developer - GitHub - https://github.com/Necralius
        //Interactable - (0.1)
        //State:  - (Needs Refactoring, Needs Coments, Needs Improvement)
        //This code represents (Code functionality or code meaning)

        private Animator intcAnim;

        [Header("Interaction Settings")]
        public string interactionDetail;
        public float interactTime;
        private float interactingTimer;

        [Header("Interaction State")]
        public bool interactionTriggerSound;
        public bool hasAnimatorInteraction;
        public bool isInteracting;

        [Header("Interaction Data and Actions")]
        public UnityEvent interactAction;
        public AudioClip interactionClip;
        public Transform interactionTextSpawn;

        private void Start()
        {
            hasAnimatorInteraction = TryGetComponent(out intcAnim);
            if (hasAnimatorInteraction) intcAnim = GetComponent<Animator>();
        }

        private void Update()
        {
            if (isInteracting)
            {
                if (interactingTimer >= interactTime) { isInteracting = false; interactingTimer = 0; }
                else interactingTimer += Time.deltaTime;
            }
        }
        public virtual void OnInteract()
        {
            if (isInteracting) return;
            isInteracting = true;
            if (interactionTriggerSound && !interactionClip.Equals(null)) GameManager.Instance.PlaySound(interactionClip);
            if (hasAnimatorInteraction) intcAnim.SetTrigger("Interact");
            interactAction.Invoke();
        }
    }
}