using UnityEngine;

namespace GoraTales.Components
{
    public class DoInteractionComponent : MonoBehaviour
    {
        public void DoInteraction(GameObject go)
        {
            var interactable = go.GetComponent<InteractiveComponent>();
            if (interactable != null)
                interactable.Interact();
        }
    }
}
