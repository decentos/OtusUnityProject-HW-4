using UnityEngine;

namespace MVCExample
{
    [CreateAssetMenu(fileName = "EnviromentSettings", menuName = "Data/Unit/EnviromentData")]
    public sealed class EnviromentData : ScriptableObject
    {
        public GameObject spaceParticle;
    }
}
