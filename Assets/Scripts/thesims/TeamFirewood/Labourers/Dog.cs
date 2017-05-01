using Ai.Goap;
using UnityEngine; 

namespace TeamFirewood
{

	public class Dog : Worker
	{

		private readonly WorldGoal worldGoal = new WorldGoal();
		public int amountToEat = 15;
		public int incrementHungerBy = 4;

		protected override void Awake()
		{
			base.Awake();
			EatAction[] actions = FindObjectsOfType (typeof(EatAction)) as EatAction[];
			foreach (EatAction a in actions) {
				this.availableActions.Add (a);
			}
			var goal = new Goal();
			goal["food"] = new Condition(CompareType.MoreThanOrEqual, amountToEat);
			worldGoal[this] = goal;
		}

		public override WorldGoal CreateGoalState()
		{
			return worldGoal;
		}

		public void wantMoreFood(){
			amountToEat += incrementHungerBy;
			worldGoal[this]["food"] = new Condition(CompareType.MoreThanOrEqual, amountToEat);
		}
	}
}