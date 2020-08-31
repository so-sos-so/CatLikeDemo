using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class Graph : MonoBehaviour
{
    public enum WhatFuncEnum
    {
        Sin,
        MulSin,
    }
    
    [Range(10,100)]
    public int Resolution = 1;
    public WhatFuncEnum WhatFunc;
    private Transform PointPrefab;
    private Transform Root;
    private Transform[] transforms;
    float step;
    Vector3 scale;
    Vector3 position = Vector3.zero;
    private Func<float, float>[] mathFuncs;
    [Button()]
    private void Start()
    {
        mathFuncs[0] = GraphFunc.SinFunc;
        mathFuncs[1] = GraphFunc.MulSinFunc;
        PointPrefab = Resources.Load<Transform>("Cube");
        step = 2f / Resolution;
        scale = Vector3.one * step;
        transforms = new Transform[Resolution];
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
            tempPosition.y = mathFuncs[(int)WhatFunc](tempPosition.x + Time.time);
            point.localPosition = tempPosition;
            point.GetComponent<MeshRenderer>().material.color = new Color(tempPosition.x, tempPosition.y, tempPosition.y);
        }
    }
}
