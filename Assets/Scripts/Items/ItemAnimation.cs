using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAnimation : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 50f;
    [SerializeField] private float bobbingSpeed = 0.5f;
    [SerializeField] private float bobbingAmount = 0.5f;
    private Vector3 _initialPosition;
    private float _time;

    private void Start()
    {
        _initialPosition = transform.position;
    }

    private void Update()
    {
        RotateItem();
        BobbingItem();
    }

    private void RotateItem()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }

    private void BobbingItem()
    {
        _time += Time.deltaTime;
        transform.position = _initialPosition + new Vector3(0, Mathf.Sin(_time * bobbingSpeed) * bobbingAmount, 0);
    }
}
