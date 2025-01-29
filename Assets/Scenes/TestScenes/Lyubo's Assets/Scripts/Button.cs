using System.Collections;
using UnityEngine;

public class Button : MonoBehaviour
{
    public float buttonSpeed = 0.1f;
    private Material material;
    public Color buttonColor = Color.red; // Default color is red

    // Use this for initialization
    void Start()
    {
        material = GetComponent<Renderer>().material;
        material.color = buttonColor;
    }

    // Update is called once per frame
    void Update() { }

    Coroutine coroutine;

    internal void Activate()
    {
        if (coroutine != null)
            StopCoroutine(coroutine);
        coroutine = StartCoroutine(ChangeObjColor(GetComponent<Renderer>().material));
    }

    private IEnumerator ChangeObjColor(Material mat)
    {
        Color originalColor = mat.color;
        mat.color = Color.green; // Change color to green on activation
        yield return new WaitForSeconds(buttonSpeed);
        mat.color = originalColor;
    }
}
