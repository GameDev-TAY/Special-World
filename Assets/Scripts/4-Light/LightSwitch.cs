using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LightSwitch : MonoBehaviour
{

    [SerializeField] GameObject Light;
    [SerializeField] GameObject trigger;
    [SerializeField] GameObject CorrectSwitch;
    public GameObject LastSwitch;
    private AudioSource Click;
    public bool onSwitch; //Change to private
    public bool hasPin = false;
   

    void OnTriggerEnter(Collider other)
    {
        if (hasPin && LastSwitch == CorrectSwitch) {
            trigger.SetActive(true);
            onSwitch = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        onSwitch = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        Click = trigger.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (onSwitch)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Light.GetComponent<Light>().enabled = !Light.GetComponent<Light>().enabled;
                trigger.GetComponent<Transform>().Rotate(0,0,90f);
                Click.Play();
                this.GetComponent<AudioSource>().Stop();
            }
        }
    }

    void OnGUI()
    {
        if (onSwitch)
        {
            if (Light.GetComponent<Light>().enabled)
            {
                GUI.Box(new Rect(0, 0, 200, 20), "Press E to close the light");
            }
            else
            {
                GUI.Box(new Rect(0, 0, 200, 20), "Press E to open the light");
            }
        }
    }
}
