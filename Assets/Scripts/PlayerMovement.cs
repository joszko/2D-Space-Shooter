using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public float maxSpeed = 5f;
    public float rotSpeed = 180f;

    float shipBoundaryRadius = 0.5f;
	
	// Update is called once per frame
	void Update () {
        //Returns a FLOAT from -1.0 to +1.0
        //Input.GetAxis("Vertical");

        //Rotate the ship
        Quaternion rot = transform.rotation;

        //grab rotation quaterian
        float z = rot.eulerAngles.z;

        //change the z angle based on input
        z -= Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;

        //recreate the quaterian
        rot = Quaternion.Euler(0, 0, z);

        //feed the quaterian into rotation
        transform.rotation = rot;


        //Move the ship
        Vector3 pos = transform.position;

        Vector3 velocity = new Vector3(0, Input.GetAxis("Vertical") * maxSpeed *  Time.deltaTime,0);

        pos += rot * velocity;

        //Restrict the player to the camera's boundaries!


        //vertical boundaries
        if (pos.y + shipBoundaryRadius > Camera.main.orthographicSize)
        {
            pos.y = Camera.main.orthographicSize-shipBoundaryRadius;
        }
        if (pos.y - shipBoundaryRadius < -Camera.main.orthographicSize)
        {
            pos.y = -Camera.main.orthographicSize + shipBoundaryRadius;
        }

        //calculating horizontal boundaries using screen ratio
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float widthOrtho = Camera.main.orthographicSize * screenRatio;

        if (pos.x + shipBoundaryRadius > widthOrtho)
        {
            pos.x = widthOrtho - shipBoundaryRadius;
        }
        if (pos.x - shipBoundaryRadius < -widthOrtho)
        {
            pos.x = -widthOrtho + shipBoundaryRadius;
        }

        //update position
        transform.position = pos;
	}
}
