using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
   private Camera mainCamera;
   
   [Header("Actions")]
   public static Action onCarrotClicked;
   public static Action<Vector2> onCarrotClickedPosition;

   private void Awake()
   {
      mainCamera = Camera.main;
   }

   private void Update()
   {
      if (Input.GetMouseButtonDown(0))
      {
         if (EventSystem.current.IsPointerOverGameObject())
            return;

         ThrowRaycast();
      }
   }

   private void ThrowRaycast()
   {
      RaycastHit2D hit = Physics2D.GetRayIntersection(mainCamera.ScreenPointToRay(Input.mousePosition));
      if (!hit.collider)
      {
         return;
      }
      
      onCarrotClicked?.Invoke();
      onCarrotClickedPosition?.Invoke(hit.point);
   }
}
