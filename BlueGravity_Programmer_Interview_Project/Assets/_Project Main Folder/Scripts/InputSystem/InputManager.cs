using UnityEngine;
using UnityEngine.InputSystem;

namespace NekraliusDevelopmentStudio
{
    public class InputManager : MonoBehaviour
    {
        //Code made by Victor Paulo Melo da Silva - Game Developer - GitHub - https://github.com/Necralius
        //InputManager - (0.3)
        //State: Functional
        //This code represents an input management and fully real time detection based in the new input system;

        #region - Singleton Pattern -
        //This structures represents an simple singleton pattern implementation
        public static InputManager Instance;
        private void Awake() => Instance = this;
        #endregion

        #region - Dependencies -
        private PlayerInput playerInput => GetComponent<PlayerInput>();
        #endregion

        #region - Input States -
        public Vector2 moveVector { get; private set; }
        public bool interacted { get; private set; }
        public bool inventoryActed { get; private set; }
        public bool reloadSceneTrigger { get; private set; }
        #endregion

        #region - Input Data -
        private InputActionMap currentMap;
        private InputAction moveAction;
        private InputAction interactAction;
        private InputAction inventoryAction;
        private InputAction reloadSceneAction;
        #endregion

        //============================Methods============================//

        #region - BuiltIn Methods -
        private void Start() => SetGeneralInpuData(); //-> Called in the game start
        private void Update() => UpdateGeneralInput(); //-> Called at every frame update
        #endregion

        #region - Input Gethering and Update -
        private void SetGeneralInpuData()
        {
            //This method gets the current action map, and get all necessary actions from the input asset.
            currentMap = playerInput.currentActionMap;

            moveAction = currentMap.FindAction("MoveAction");
            interactAction = currentMap.FindAction("Interact");
            inventoryAction = currentMap.FindAction("InventoryAct");
            reloadSceneAction = currentMap.FindAction("ReloadScene");
        }
        private void UpdateGeneralInput()
        {
            //This methods gets the input actions values every frame and save this data in equivalent variables.
            moveVector = moveAction.ReadValue<Vector2>().normalized;
            interacted = interactAction.triggered;
            inventoryActed = inventoryAction.triggered;
            reloadSceneTrigger = reloadSceneAction.triggered;
        }
        #endregion
    }
}