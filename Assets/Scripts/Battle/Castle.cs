public class Castle : BattleObject
{
    // Define the belonging of the castle
    public ObjectTeam CastleTeam = ObjectTeam.Player;

    private void Awake()
    {
        // Set up the properties of the castle
        this.Team = CastleTeam;
        this.Health = 100;

        // Store the castle for later reference in the battle
        BattleManager.RegisterObject(this);
    }
}
