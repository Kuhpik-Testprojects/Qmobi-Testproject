using Source.Scripts.Statics.Environment;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Source.Scripts.Managers
{
    [RequireComponent(typeof(PlayerInput))]
    public class InputReadingManager : MonoBehaviour
    {
        /// <summary>
        /// Used in Player Input component via Inspector
        /// </summary>
        public void OnPlayerInput(InputAction.CallbackContext context)
        {
            var value = context.ReadValue<Vector2>();

            if ((value.x == 0 || value.y == 0) && //Disallow inputs like (1,1)
                 value != Vector2.zero) //For some readon input system throwing (0,0) values
            {
                GameEvents.UserInputEvent.Invoke(Vector2Int.RoundToInt(value));
            }
        }
    }
}
