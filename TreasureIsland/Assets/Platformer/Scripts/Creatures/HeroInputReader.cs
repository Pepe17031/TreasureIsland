using UnityEngine;
using UnityEngine.InputSystem;
//Скрипт обработки управления, настройки в папке UserInput

namespace GoraTales.Creatures
{
    public class HeroInputReader : MonoBehaviour
    {
        [SerializeField] private Hero _hero; // Импорт скрипта в насройках элемента

        public void OnMovement(InputAction.CallbackContext context) // Лево/Право
        {
            var direction = context.ReadValue<Vector2>();
            _hero.SetDirection(direction);
        }
        
        public void OnInteract(InputAction.CallbackContext context)
        {
            if (context.canceled)
            {
                _hero.Interact();
            }
        }
        
        public void OnAttack(InputAction.CallbackContext context)
        {
            if (context.canceled)
            {
                _hero.Attack();
            }
        }
    }

}