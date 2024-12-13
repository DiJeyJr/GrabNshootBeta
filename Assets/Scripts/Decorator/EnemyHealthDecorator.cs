

using System.Collections;
using UnityEngine;

public class EnemyHealthDecorator : HealthDecorator
{
    private int _regenAmount;
    private float _regenInterval;
    private MonoBehaviour _monoBehaviour;

    public EnemyHealthDecorator(IHealthSystem health, MonoBehaviour monoBehaviour, int regenAmount, float regenInterval) : base(health)
    {
        _monoBehaviour = monoBehaviour;
        _regenAmount = regenAmount;
        _regenInterval = regenInterval;
        StartRegeneration();
    }

    private void StartRegeneration()
    {
        _monoBehaviour.StartCoroutine(RegenerateHealth());
    }

    private IEnumerator RegenerateHealth()
    {
        while (true)
        {
            yield return new WaitForSeconds(_regenInterval);
            base.GetHeal(_regenAmount);
        }
    }
}