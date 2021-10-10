using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
namespace Data
{
    public enum JudgeTypeEnum
    {
        Tap, Wave, Multi
    }
    public class Judge
    {
        public JudgeTypeEnum Type { get; set; }
        public int Time { get; set; } = 0;

        // for JudgeTypeEnum.Tap, JudgeTypeEnum.Wave
        public float JudgePos { get; set; } = 0f;

        // for JudgeTypeEnum.Multi
        public int JudgeTimes { get; set; } = 0;
    }
    public class LevelData
    {
        public List<Judge> TopJudges { get; set; }
        public List<Judge> BottomJudges { get; set; }

        public float Speed { get; set; } = 1f;
        // 谱面长度（单位s）
        public int Length { get; set; } = 114514;
    }
}