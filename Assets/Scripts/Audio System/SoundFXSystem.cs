public class SoundFXSystem : AudioSystem
{
    private void OnEnable()
    {
        Enemy.onEnemyDeath += () => Play(SoundID.SPLAT);
    }
    private void OnDisable()
    {
        Enemy.onEnemyDeath -= () => Play(SoundID.SPLAT);
    }

}