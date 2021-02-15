using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface FireWatcher
{
    void onDestruction();
}
public class FireScript : MonoBehaviour
{
    public FireWatcher watcher;

    private void OnDestroy()
    {
        watcher?.onDestruction();
    }
}
