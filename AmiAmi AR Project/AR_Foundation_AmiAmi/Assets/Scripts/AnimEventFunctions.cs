﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimEventFunctions : MonoBehaviour
{
    public void DestroyParent()
    {
        Destroy(gameObject.transform.parent.gameObject);
    }

}
