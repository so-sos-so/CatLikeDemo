using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class Graph : MonoBehaviour
{
    public Transform PointPrefab;
    [Range(10,100)]
    public int Resolution = 1;
    public Transform Root;
    private Material colorMat;
    private Transform[] transforms;
    float step;
    Vector3 scale;
    Vector3 position = Vector3.zero;
    [Button()]
    private void Start()
    {
        step = 2f / Resolution;
        scale = Vector3.one * step;
        transforms = new Transform[Resolution];
        colorMat = Resources.Load<Material>("Color");
        if (Root != null)
        {
            DestroyImmediate(Root.gameObject);
        }
        Root = new GameObject("Root").transform;
        Root.localPosition = Vector3.zero;

        for (int i = 0; i < Resolution; i++)
        {
            Transform point = Instantiate(PointPrefab, Root);
            position.x = i * step - 1;
            point.localPosition = position;
            point.localScale = scale;
            transforms[i] = point;
        }
    }

    public float Timer;
    private float timer;
    
    private void Update()
    {
        timer += Time.deltaTime;
        if(timer < Timer) return;
        timer = 0;
        for (int i = 0; i < Resolution; i++)
        {
            Transform point = transforms[i];
            var tempPosition = point.position;
            tempPosition.y = Mathf.Sin(Mathf.PI * (tempPosition.x + Time.time));
            point.localPosition = tempPosition;
            point.GetComponent<MeshRenderer>().material.color = new Color(tempPosition.x, tempPosition.y, tempPosition.y);
        }
    }
}
