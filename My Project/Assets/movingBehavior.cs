using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movingBehavior : MonoBehaviour
{
    public GameObject Obstacle;
    public GameObject plate;
    public float speed = 10f;
    private int NumItems = 5;
    public Text message;

    void Start()
    {
        plate.gameObject.GetComponent<Renderer>().material.color = Color.green;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.down * 5 * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        if (NumItems <= 0)
        {
            message.text = "game over!";
            this.gameObject.SetActive(false);
        }
        else message.text = NumItems.ToString();
    }

    private void OnCollisionEnter(Collision collision)
    {
        this.gameObject.GetComponent<Renderer>().material.color = Color.red;
        NumItems--;
    }

    private void OnCollisionExit(Collision collision)
    {
        this.gameObject.GetComponent<Renderer>().material.color = Color.white;
    }

    private void OnCollisionStay(Collision collision) { }

    public void heal()
    {
        NumItems = 5;
    }
}
