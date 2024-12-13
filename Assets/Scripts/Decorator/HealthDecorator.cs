public abstract class HealthDecorator : IHealthSystem
{
    protected IHealthSystem decoratedHealth;

    public HealthDecorator(IHealthSystem health)
    {
        decoratedHealth = health;
    }

    public virtual float GetHealth()
    {
        return decoratedHealth.GetHealth();
    }

    public virtual void GetDamage(float damage)
    {
        decoratedHealth.GetDamage(damage);
    }

    public virtual void GetHeal(float heal)
    {
        decoratedHealth.GetHeal(heal);
    }

    public virtual void ResetHealth()
    {
        decoratedHealth.ResetHealth();
    }
}