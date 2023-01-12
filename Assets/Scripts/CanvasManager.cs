using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CanvasManager : MonoBehaviour
{
    public UnityEvent canvasControl;

    private void DisableCanvas()
    {
        canvasControl.Invoke();
    }
}
