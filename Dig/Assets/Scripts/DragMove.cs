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

    public int level;

    private float yRotate = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        movementOption = 0;
        if (level == 1) moveSpeed = 5f;
        else if (level == 2) moveSpeed = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.RotateAround(transform.position, transform.up, Time.deltaTime * 90f * 5f);
        if (movementOption == 0)
        {
            yRotate += 1.0f;
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                //touchPosition.z = 0;
                direction.x = (touchPosition.x - transform.position.x);
                direction.z = (touchPosition.z - transform.position.z);

                
                pos = transform.position;
                Vector3 velocity = new Vector3(direction.x, direction.y, 0) * moveSpeed * Time.deltaTime;
                Vector3 diff = touchPosition - transform.position;

                diff.Normalize();
                float rotZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
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
                //transform.rotation = Quaternion.Euler(0f, 0f, rotZ - (90 + 180));
                if(yRotate >= 180.0f)
                {
                    yRotate = -180.0f;
                }
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, transform.rotation.y, rotZ - (90+180)), Time.fixedDeltaTime * 5f);

                //transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.fixedDeltaTime * 5f);
            }
            else
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, transform.rotation.y, 0f), Time.fixedDeltaTime * 5f);
            }
            //transform.RotateAround(transform.position, transform.up, Time.deltaTime * 90f * 5f);
        }
 
    }
}
