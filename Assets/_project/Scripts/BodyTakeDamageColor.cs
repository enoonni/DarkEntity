using System.Collections;
using UnityEngine;
using Gameplay;
using System;

public class BodyTakeDamageColor : MonoBehaviour
{
    public static BodyTakeDamageColor Instance;
    [SerializeField] private GameObject _object;
    private IDamageable _damageable;

    private void Awake()
    {
        Instance = this;
        _damageable = _object.GetComponent<IDamageable>();
    }

    private void Start()
    {
        if (_damageable != null)        
            _damageable.OnDamageTaken += SwitchColor;
    }

    public void SwitchColor(object sender, EventArgs eventArgs)
    {
        GameObject objectToChangeColor = this.gameObject;
        Renderer renderer = objectToChangeColor.GetComponent<Renderer>();
        renderer.material.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);

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
