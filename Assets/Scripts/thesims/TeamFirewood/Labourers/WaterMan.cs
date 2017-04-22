using Ai.Goap;

namespace TeamFirewood {
public class WaterMan : Worker {
    private readonly WorldGoal worldGoal = new WorldGoal();

    protected override void Awake() {
        base.Awake();
        var goal = new Goal();
        goal[Item.Water.ToString()] = new Condition(CompareType.MoreThan, 8);   
        worldGoal[this] = goal;
    }

    public override WorldGoal CreateGoalState() {
        return worldGoal;
    }
}
}
