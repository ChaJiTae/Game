﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlayer : MonoBehaviour{
    public void destroyEvent()
    {
        Destroy(gameObject);
    }
}
