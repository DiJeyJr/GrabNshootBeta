// Nombre del archivo: AttackingState.cs
using UnityEngine;

public class AttackingState : IEnemyState
{
    private bool alreadyAttacked = false; // Controla el cooldown del ataque
    private float attackCooldown = 2f;   // Tiempo entre ataques (en segundos)

    public void EnterState(EnemyStateManager enemy)
    {
        //Debug.Log("Enemy is attacking the player.");
    }

    public void UpdateState(EnemyStateManager enemy)
    {
        // Asegúrate de que el enemigo no se mueva mientras ataca
        enemy.agent.SetDestination(enemy.transform.position);

        // Gira para mirar al jugador
        Vector3 direction = (enemy.player.position - enemy.transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        enemy.transform.rotation = Quaternion.Slerp(enemy.transform.rotation, lookRotation, Time.deltaTime * 5f);

        // Realiza el ataque si no está en cooldown
        if (!alreadyAttacked)
        {
            Attack(enemy);
        }

        // Si el jugador se aleja, vuelve al estado de persecución
        if (!Physics.CheckSphere(enemy.transform.position, enemy.attackRange, enemy.whatIsPlayer))
        {
            enemy.SwitchState(enemy.ChasingState);
        }
    }

    public void ExitState(EnemyStateManager enemy)
    {
        //Debug.Log("Enemy stopped attacking.");
    }

    private void Attack(EnemyStateManager enemy)
    {
        // Simula daño al jugador
        Player.Instance.TakeDamage(10f);
        //Debug.Log("Player hit!");

        // Activa el cooldown
        alreadyAttacked = true;

        // Usa un temporizador para desactivar el cooldown
        enemy.StartCoroutine(ResetAttackCooldown());
    }

    private System.Collections.IEnumerator ResetAttackCooldown()
    {
        yield return new WaitForSeconds(attackCooldown);
        alreadyAttacked = false;
    }
}