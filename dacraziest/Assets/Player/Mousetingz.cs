using UnityEngine;

public class Mousetingz : MonoBehaviour
{   

    public float PlayerSensitivity = 100f;
    public Transform playerbody;
    float yRotation = 0f;
    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //mouse movement

        //get mouse movement
        float mouseX = Input.GetAxis("Mouse X") * PlayerSensitivity * Time.deltaTime; 
        float mouseY = Input.GetAxis("Mouse Y") * PlayerSensitivity * Time.deltaTime;

        //restrict horisontal mouse movement
        yRotation -= mouseY;
        yRotation = Mathf.Clamp(yRotation, -90f, 90f);

        xRotation += mouseX;

        //apply rotation to camera
        transform.localRotation = Quaternion.Euler(yRotation, 0f, 0f);

        //apply rotation to playerbody
        playerbody.Rotate(Vector3.up * mouseX);
    }
}
