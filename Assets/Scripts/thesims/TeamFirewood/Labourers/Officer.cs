using Ai.Goap;

namespace TeamFirewood
{

    public class Officer : Worker
    {

        private readonly WorldGoal worldGoal = new WorldGoal();
		public int amountToSmoke = 6;

        protected override void Awake()
        {
            base.Awake();
            var goal = new Goal();
			goal["used"+Item.Weed.ToString()] = new Condition(CompareType.MoreThanOrEqual, amountToSmoke);
            worldGoal[this] = goal;
        }

        public override WorldGoal CreateGoalState()
        {
            return worldGoal;
        }
    }
}