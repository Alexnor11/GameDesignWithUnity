using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthModifier : MonoBehaviour
{
    [SerializeField, Tooltip("��������� �������� ��� ���������� � �������")]
    float _healthChange = 0;

    [SerializeField, Tooltip("����� ������� ������� ������ ���� ���������")]
    DamageTarget _applyToTarget = DamageTarget.Player;

    public enum DamageTarget
    {
        Player,
        Enemies,
        All,
        None
    }

    [SerializeField, Tooltip("������ ������ ���������������� ��� ������������?")]
    bool _destroyOnCollision = false;

    private void OnTriggerStay(Collider collider)
    {
        GameObject hitObj = collider.gameObject;
        HealthManager healthManager = hitObj.GetComponent<HealthManager>();

        if (healthManager && IsValidTarget(hitObj))
        {
            healthManager.AdjustCurHealth(_healthChange);

            if (_destroyOnCollision)
                GameObject.Destroy(gameObject);
        }
    }

    bool IsValidTarget(GameObject possibleTarget)
    {
        if (_applyToTarget == DamageTarget.All)
        {
            return true;
        }
        else if (_applyToTarget == DamageTarget.None)
            return false;
        else if (_applyToTarget == DamageTarget.Player && possibleTarget.GetComponent<PlayerController>())
            return true;
        else if (_applyToTarget == DamageTarget.Enemies && possibleTarget.GetComponent<AIBrain>())
            return true;

        return false;
    }
}
