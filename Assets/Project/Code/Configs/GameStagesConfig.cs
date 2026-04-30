using UnityEngine;

namespace Project.Code.Configs
{
    [CreateAssetMenu(fileName = "GameStagesConfig", menuName = "Configs/GameStagesConfig", order = 51)]
    public class GameStagesConfig : ScriptableObject
    {
        [SerializeField] private int[] _scoreThresholds;
        [SerializeField] private int[] _objectsToAddPerStage;
        [SerializeField] private float[] _extraYOffsetPerStage;
        
        public int StagesCount => _scoreThresholds.Length;
        public int[] ScoreThresholds => _scoreThresholds;
        public int[] ObjectsToAddPerStage => _objectsToAddPerStage;
        public float[] ExtraYOffsetPerStage => _extraYOffsetPerStage;
    }
}
