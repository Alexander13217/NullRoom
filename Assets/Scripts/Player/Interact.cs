using Anomaly;
using TMPro;
using UnityEngine;

namespace Player
{
    public class Interact : MonoBehaviour
    {
        [SerializeField] private TMP_Text _interact;
        [SerializeField] private float _interactDistance;
        [SerializeField] private Camera _camera;
        [SerializeField] private LayerMask _interactLayer;

        private void Update()
        {
            TryInteract();
        }

        private void TryInteract()
        {
            _interact.text = "";

            if (Ray(out RaycastHit hit) == false)
                return;

            if (hit.collider.TryGetComponent(out IInteractable obj) == false)
                return;

            _interact.text = obj.GetClue();

            if (Input.GetKeyDown(KeyCode.E))
            {
                obj.Interact();
            }
        }

        private bool Ray(out RaycastHit hit)
        {
            Ray ray = _camera.ScreenPointToRay(
                new Vector3(Screen.width / 2f, Screen.height / 2f));

            return Physics.Raycast(ray, out hit,_interactDistance,_interactLayer);
        }
    }
}
