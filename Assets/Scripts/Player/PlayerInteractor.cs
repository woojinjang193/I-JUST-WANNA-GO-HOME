using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractor : MonoBehaviour
{

    [SerializeField] private float maxDistance = 3f;
    [SerializeField] private InputActionReference interactAction;

    [SerializeField] private Camera cam;


    void OnEnable()
    {
        interactAction.action.started += OnInteract;
        interactAction.action.Enable();
    }

    void OnDisable()
    {
        interactAction.action.started -= OnInteract;
        interactAction.action.Disable();
    }

    private void OnInteract(InputAction.CallbackContext context)
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, maxDistance))
        {
            var col = hit.collider;

            if (col.CompareTag("Item"))
            {
                Debug.Log($"아이템: {col.name}");
            }  
            else if (col.CompareTag("NPC"))
            {
                Debug.Log($"NPC: {col.name}");
            } 
            else if (col.CompareTag("InteractableOBJ"))
            {
                Debug.Log($"상호작용 가능: {col.name}");
            }
            else
            {
                Debug.Log($"상호작용 불가능: {col.name}");
            }  
        }
        else
        {
            Debug.Log("아무것도 감지되지 않음");
        }
    }

    private void OnDrawGizmos()
    {

        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(cam.transform.position, cam.transform.forward * maxDistance);
        Gizmos.DrawWireSphere(cam.transform.position + cam.transform.forward * maxDistance, 0.1f);
    }
}
