using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Effects", menuName = "Effects/Make New Effect/Buffs", order = 0)]
public class EffectBuffSO : ScriptableObject
{
    [SerializeField]
    public GameObject _effectPrefab = null;
    [SerializeField]
    private bool _isItMoney = false;
    [SerializeField]
    private bool _isEffectHasRadious = false;
    [SerializeField]
    private bool _isEffectHasDuration = true;
    [SerializeField]
    private bool _isEffectWithoutStats = false;
    [SerializeField]
    private float _heal;
    [SerializeField]
    private float _speedUpValue;
    [SerializeField]
    private float _radiousValue;
    [SerializeField]
    private float _duration;
    [SerializeField]
    private int _moneyValue;

    public bool IsEffectWithoutStats => _isEffectWithoutStats;
    public bool IsEffectHasRadious => _isEffectHasRadious;
    public bool IsEffectHasDuration => _isEffectHasDuration;

    public float Duration => _duration;
    public float HealValue => _heal;
    public float SpeedUpValue => _speedUpValue;
    public float RadiousValue => _radiousValue;

#if UNITY_EDITOR
    [UnityEditor.CustomEditor(typeof(EffectBuffSO))]
    public class MyEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            var effectSO = (EffectBuffSO)target;

            effectSO._effectPrefab = EditorGUILayout.ObjectField("Effect prefab", effectSO._effectPrefab, typeof(GameObject), true) as GameObject;
            effectSO._isItMoney = EditorGUILayout.Toggle("Is It Money ?", effectSO._isItMoney);
            if (!effectSO._isItMoney)
            {
                effectSO._isEffectWithoutStats = EditorGUILayout.Toggle("Is Effect Without Stats ?", effectSO._isEffectWithoutStats);
                effectSO._isEffectHasRadious = EditorGUILayout.Toggle("Is Effect Has Radious ?", effectSO._isEffectHasRadious);
                effectSO._isEffectHasDuration = EditorGUILayout.Toggle("Is Effect Has Duration ?", effectSO._isEffectHasDuration);
            }
            if (effectSO._isEffectHasDuration && !effectSO._isItMoney)
            {
                effectSO._duration = EditorGUILayout.Slider("Duration in sec", effectSO._duration, 0, 20);
            }

            if (!effectSO._isEffectWithoutStats && !effectSO._isItMoney)
            {
                effectSO._heal = EditorGUILayout.FloatField("Heal value", effectSO._heal);
                effectSO._speedUpValue = EditorGUILayout.FloatField("Speed up value", effectSO._speedUpValue);
            }
            if (effectSO._isEffectHasRadious && !effectSO._isItMoney)
            {
                effectSO._radiousValue = EditorGUILayout.Slider("Radious value", effectSO._radiousValue, 0, 50);
            }
            if (effectSO._isItMoney)
            {
                effectSO._moneyValue = EditorGUILayout.IntField("Money value",effectSO._moneyValue);
            }
            serializedObject.ApplyModifiedProperties();
        }
    }
#endif
}
enum EFFECTS_BONUS
{
    Magnit,
    Coin,
    Shield,
    SpedUp
}
