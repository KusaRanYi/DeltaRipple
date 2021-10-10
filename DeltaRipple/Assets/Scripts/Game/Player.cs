using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data;
using System.IO;
using Newtonsoft.Json;
public class Player : MonoBehaviour
{
    public string LevelPath = "";
    private LevelData Level;
    public DragButton TopDragButton;
    public DragButton BottomDragButton;
    public RectTransform TopViewport;
    public RectTransform BottomViewport;
    public static string PreloadLevelPath = null;
    void Awake()
    {
        if(PreloadLevelPath != null)
        {
            LevelPath = PreloadLevelPath;
            PreloadLevelPath = null;
        }
    }
    void Start()
    {
        // load level
        if (!string.IsNullOrEmpty(LevelPath))
        {
            Level = JsonConvert.DeserializeObject<LevelData>(
                File.ReadAllText(LevelPath));
            LoadLevel();
        }
    }
    void LoadLevel()
    {
        foreach (var judge in Level.TopJudges)
        {

        }
        foreach (var judge in Level.BottomJudges)
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
