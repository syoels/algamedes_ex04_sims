using Ai.Goap;

namespace TeamFirewood {
public class BroForReal : Worker {
    private readonly WorldGoal worldGoal = new WorldGoal();

    protected override void Awake() {
        base.Awake();
        var goal = new Goal();
			goal["friendIsHappy"] = new Condition(CompareType.Equal, true);   
        worldGoal[this] = goal;
    }

    public override WorldGoal CreateGoalState() {
        return worldGoal;
    }
}
}
