using Ai.Goap;

namespace TeamFirewood
{

	public class Dog : Worker
	{

		private readonly WorldGoal worldGoal = new WorldGoal();
		public int amountToEat = 15;

		protected override void Awake()
		{
			base.Awake();
			var goal = new Goal();
			goal["food"] = new Condition(CompareType.MoreThanOrEqual, amountToEat);
			worldGoal[this] = goal;
		}

		public override WorldGoal CreateGoalState()
		{
			return worldGoal;
		}
	}
}