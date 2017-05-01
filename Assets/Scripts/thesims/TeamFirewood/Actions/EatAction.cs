using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Ai.Goap;

namespace TeamFirewood {
    /// <summary>
    /// Pick up a tool from a harvest point.
    /// </summary>
    public class EatAction : GoapAction {
        private List<IStateful> targets;
		public int eatAmount = 2;
		public Item resource; 

        protected void Awake() {
			AddTargetPrecondition (resource.ToString (), CompareType.MoreThanOrEqual, eatAmount);
			AddTargetEffect (resource.ToString (), ModificationType.Add, -eatAmount);
			AddEffect("food", ModificationType.Add, eatAmount);
        }

        protected void Start() {
			RefreshTargets ();
        }

        public override bool RequiresInRange() {
            return true;
        }

        public override List<IStateful> GetAllTargets(GoapAgent agent) {
			RefreshTargets ();
            return targets;
        }

		private void RefreshTargets(){
			List<IStateful> weedTargets = GetTargets<Weed>();
			List<IStateful> candyTargets = GetTargets<Candy>();
			targets = new List<IStateful> ();
			foreach (IStateful w in weedTargets) {
				targets.Add (w);
			}
			foreach (IStateful c in candyTargets) {
				targets.Add (c);
			}
		}


		protected override bool OnDone(GoapAgent agent, WithContext context) {
			
			if (context.target.GetType () == typeof(Weed)) {
				Weed weed = context.target as Weed; 	
				if (weed != null && weed.ToString () != "Null" && weed.ToString () != "null") {
					weed.amount -= eatAmount;
				}
				if (weed.amount <= 0) {
					GameObject weedObj = weed.gameObject; 
					Destroy (weedObj);
				}

			} else {
				Candy candy = context.target as Candy;
				if (candy != null && candy.ToString () != "Null" && candy.ToString () != "null") {
					candy.amount -=eatAmount;
				}
				if (candy.amount <= 0) {
					GameObject candyObj = candy.gameObject; 
					Destroy (candyObj);
				}

			}
			RefreshTargets ();
			return base.OnDone(agent, context);
		}
    }
}
