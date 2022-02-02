using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeManager : MonoBehaviour
{
    private static CodeManager _instance;
    public static CodeManager Instance { get { return _instance; } }

    public MoveCamera MoveCamera_;
    public PresidentController PresidentController_;
    public GameObject ScreenCanvas;
    public ScreenSpaceCanvasController ScreenCanvasController;
    public GameObject WorldCanvas;
    public WorldSpaceCanvasController WorldCanvasController;
    public ReportersController ReportersController_;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
}
