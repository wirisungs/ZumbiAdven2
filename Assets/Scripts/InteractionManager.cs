using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionManager : MonoBehaviour
{
    public LayerMask playerLayer;
    public GameObject InteractBtn;
    public float RaycastDistance = 2f;

    public void InteractButton()
    {
        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, Vector2.left, RaycastDistance, playerLayer);
        RaycastHit2D hitRight = Physics2D.Raycast(transform.position, Vector2.right, RaycastDistance, playerLayer);

        if(hitLeft.collider != null || hitRight.collider != null)
            InteractBtn.SetActive(true);
        else
            InteractBtn.SetActive(false);
    }

}
