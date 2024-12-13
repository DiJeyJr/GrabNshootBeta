public interface IHealthSystem
{
    float GetHealth();
    void GetDamage(float damage);
    void GetHeal(float heal);
    void ResetHealth();
}