using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Serialization;

public class Grounded : MonoBehaviour
{
   private CapsuleCollider2D _capsuleCollider2D;
   [SerializeField] 
   private LayerMask groundMask;

   void Start()
   {
      groundMask = LayerMask.GetMask("Ground");
      _capsuleCollider2D = GetComponent<CapsuleCollider2D>();
   }

   public bool IsGrounded()
   {
      
      float height = 0.1f;
      var bounds = _capsuleCollider2D.bounds;
      Color rayColor;
      

      RaycastHit2D raycastHit = Physics2D.Raycast(bounds.center, Vector2.down, bounds.extents.y + height, groundMask);
      if (raycastHit.collider != null)
      {
         rayColor = Color.green;
      }
      else
      {
         rayColor = Color.red;
      }
      Debug.DrawRay(_capsuleCollider2D.bounds.center, Vector2.down * (bounds.extents.y + height), rayColor);

      return raycastHit;
     
   }
}
