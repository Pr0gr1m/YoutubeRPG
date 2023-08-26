using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Rigidbody rigid; //Reference to the rigidbody of the character

    public float MovementSpeed = 1; //The speed at which character moves

    void Start()
    {
        rigid = GetComponent<Rigidbody>(); //We get the rigidbody of the character
    }

    void Update()
    {
        float Vertical = Input.GetAxis("Vertical"); //This is used to determine W and S. 1 is W -1 is S
        float Horizontal = Input.GetAxis("Horizontal"); //This one determines A and D the same way as before

        Horizontal = Invert(Horizontal);
        Vertical = Invert(Vertical);

        Vector3 MoveVector; //This is vector that we will use to determine the movement
        MoveVector = new Vector3(Horizontal, 0, Vertical);

        //Now we apply the vector to a character
        rigid.AddForce(MoveVector * MovementSpeed);
    }

    //Function used to invert the values
    public float Invert(float value)
    {
        if(value >= 0)
        {
            return -value;
        }

        return Mathf.Abs(value);
    }
}
