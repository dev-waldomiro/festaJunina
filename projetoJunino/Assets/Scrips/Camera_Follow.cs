using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;

    [Range(0, 20)]
    public float smoother = 0.125f;
    public Vector3 compensador;

    void FixedUpdate()
    {
        Vector3 posicaoDesejada = target.position + compensador;
        Vector3 posicaoLisa = Vector3.Lerp(transform.position, posicaoDesejada, smoother * Time.deltaTime);
        transform.position = posicaoLisa;
    }
}
