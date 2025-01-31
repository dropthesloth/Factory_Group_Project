using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteScript : MonoBehaviour
{
    public GameObject note;
    public GameObject closingText;
    public AudioSource Opening;
    public AudioSource Closing;
    // Start is called before the first frame update
    void Start()
    {
        note.SetActive(false);
        closingText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (note.activeSelf && Input.GetKeyDown(KeyCode.Space) /*|| Input.GetMouseButtonDown(0)*/)
        {
            note.SetActive(false);
            closingText.SetActive(false);
            Closing.Play();
        }
    }
    void OnMouseDown()
    {
        Debug.Log("clicked note");
        //if (!note.activeSelf)
        note.SetActive(true);
        closingText.SetActive(true);
        Opening.Play();
    }
}
