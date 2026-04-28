using System.Collections.Generic;
using UnityEngine;

namespace Project.Code.Configs
{
    [CreateAssetMenu(fileName = "GameStagesConfig", menuName = "Configs/GameStagesConfig", order = 51)]
    public class GameStagesConfig : ScriptableObject
    {
        [SerializeField] private int[] _scoreThresholds;
        [SerializeField] private int[] _objectsToAddPerStage;
        [SerializeField] private float[] _maxYOffsetPerStage;
    
        public int[] ScoreThresholds => _scoreThresholds;
        public int[] ObjectsToAddPerStage => _objectsToAddPerStage;
        public float[] MaxYOffsetPerStage => _maxYOffsetPerStage;
    }
}
