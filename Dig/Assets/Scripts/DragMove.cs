using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragMove : MonoBehaviour
{
    private Vector3 touchPosition;
    private Vector3 direction;
    private float moveSpeed = 5f;
    private Vector3 pos;
    private float playerRadius = 0.5f;
    private int movementOption;
    // Start is called before the first frame update
    void Start()
    {
        movementOption = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(movementOption == 0)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                touchPosition.z = 0;
                direction.x = (touchPosition.x - transform.position.x);
                pos = transform.position;
                Vector3 velocity = new Vector3(direction.x, direction.y, 0) * moveSpeed * Time.deltaTime;
                pos += velocity;

                float screenRatio = (float)Screen.width / (float)Screen.height;
                float widthOrtho = Camera.main.orthographicSize * screenRatio;
                if (pos.x + playerRadius > widthOrtho)
                {
                    pos.x = widthOrtho - playerRadius;
                }
                if (pos.x - playerRadius < -widthOrtho)
                {
                    pos.x = -widthOrtho + playerRadius;
                }
                if (touch.phase == TouchPhase.Ended)
                    velocity = Vector3.zero;
                transform.position = pos;
            }
        }
 
    }
}
