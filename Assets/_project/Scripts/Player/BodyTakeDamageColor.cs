using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyTakeDamageColor : MonoBehaviour
{
    public static BodyTakeDamageColor Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void SwitchColor()
    {
        GameObject objectToChangeColor = this.gameObject;
        Renderer renderer = objectToChangeColor.GetComponent<Renderer>();
        renderer.material.color = new Color(1.0f, 0.0f, 0.0f, 1.0f); // Красный цвет

        StartCoroutine(BackWhiteColor());
    }

    private IEnumerator BackWhiteColor()
    {
        yield return new WaitForSeconds(0.2f);

        GameObject objectToChangeColor = this.gameObject;
        Renderer renderer = objectToChangeColor.GetComponent<Renderer>();
        renderer.material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    }
}
