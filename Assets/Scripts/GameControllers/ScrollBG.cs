using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBG : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private float yOffset;
    private Material bgMat;

    private void Awake()
    {
        bgMat = GetComponent<Renderer>().material;
    }

    private void Update()
    {
        yOffset += moveSpeed * Time.deltaTime;
        bgMat.SetTextureOffset("_MainTex", new Vector2(0f, yOffset));
    }
}
