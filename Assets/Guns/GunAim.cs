using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAim : MonoBehaviour
{

    [SerializeField] float offsetX, offsetY;
    [SerializeField] bool isUpsideDown = false;
    [SerializeField] bool canRotate = false; public bool CanRotate {  set { canRotate = value; } }
    [SerializeField] PlayerInput player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInput>();
    }

    void Update()
    {
        //if (canRotate)
            Rotate();
        
    }

    private void FlipVertically()
    {
        isUpsideDown = !isUpsideDown;
        Vector2 theScale = transform.localScale;
        theScale.y *= -1;
        transform.localScale = theScale;
    //    Debug.Log("Flip");
    }

    public void FlipHorizontally()
    {
        Vector2 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void Rotate()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.transform.position.z;
        Vector3 objectPosition = Camera.main.WorldToScreenPoint(player.transform.position);
        mousePosition.x = mousePosition.x - objectPosition.x;
        mousePosition.y = mousePosition.y - objectPosition.y;
        float angle = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        if ((angle > 90 && angle < 180 && !isUpsideDown) || (angle > 0 && angle < 90 && isUpsideDown) || (angle > -90 && angle < 0 && isUpsideDown) || (angle > -180 && angle < -90 && !isUpsideDown))
        {
            FlipVertically();
            player.Flip();
            FlipHorizontally();
        }
    }
}
