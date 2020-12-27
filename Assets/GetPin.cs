using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPin : MonoBehaviour
{
    [SerializeField] GameObject Box;
    private AudioSource foundBox;
    public bool onPin; //Change to private

    void OnTriggerEnter(Collider other)
    {
        onPin = true;
    }

    void OnTriggerExit(Collider other)
    {
        onPin = false;
    }

    void Start()
    {
        foundBox = Box.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (onPin)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                this.gameObject.SetActive(false);
                Box.GetComponent<LightSwitch>().hasPin = true;
                Box.GetComponent<LightSwitch>().LastSwitch = this.gameObject;
                foundBox.Play();
            }
        }
    }

    void OnGUI()
    {
        if (onPin)
        {
            GUI.Box(new Rect(0, 0, 200, 20), "Press E to Get the switch");
        }
    }
}
