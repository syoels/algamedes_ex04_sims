using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Ai.Goap;

namespace TeamFirewood {
    /// <summary>
    /// Pick up a tool from a harvest point.
    /// </summary>
    public class UseResource : GoapAction {
        public Item item;
        private List<IStateful> targets;
		public int amountToUse = 1;

        protected void Awake() {
			AddPrecondition(item.ToString(), CompareType.MoreThanOrEqual, amountToUse);
			AddEffect("used" + item.ToString(), ModificationType.Add, amountToUse);
			AddEffect(item.ToString(), ModificationType.Set, -amountToUse);
        }

        protected void Start() {
			targets = GetTargets<PointOfInterest>();
        }

        public override bool RequiresInRange() {
            return false;
        }

        public override List<IStateful> GetAllTargets(GoapAgent agent) {
            return targets;
        }

        protected override bool OnDone(GoapAgent agent, WithContext context) {
			Container c = agent.GetComponent<Container> ();
			c.items [item] -= amountToUse;
            return base.OnDone(agent, context);
        }
    }
}
