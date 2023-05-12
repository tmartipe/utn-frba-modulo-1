public class PlayerLife : Life
{
    protected override void TakeDamage(int damage)
    {
        currentLife -= damage;
        HUDManager.Instance.UpdateHeartIcons(currentLife);
        //TODO: Death logic
    }
}