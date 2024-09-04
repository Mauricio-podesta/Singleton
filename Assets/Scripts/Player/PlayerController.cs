using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float Speedvalue;
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    void Movement()
    {
        float movementbackfoward = Input.GetAxis("Vertical") * Speedvalue;
        float movementrigthleft = Input.GetAxis("Horizontal") * Speedvalue;
        movementbackfoward *= Time.deltaTime;
        movementrigthleft *= Time.deltaTime;
        transform.Translate(movementrigthleft, movementbackfoward, 0);
    }

}
