﻿using UnityEngine;

interface ISaveable
{
    object CaptureState();
    void RestoreState(object state);
}
