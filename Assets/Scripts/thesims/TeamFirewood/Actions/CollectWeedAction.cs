using System.Collections.Generic;
using UnityEngine;
using Ai.Goap;

namespace TeamFirewood {
/// <summary>
/// Like harvest action but doesn't require a tool.
/// </summary>
    public class CollectWeedAction : GoapAction {
		private const Item resource = Item.Weed;
        public int amountToHarvest;
        public int maxAmountToCarry;
        private List<IStateful> targets;
        public bool fromBros = false;

        protected virtual void Awake() {
            AddPrecondition(resource.ToString(), CompareType.LessThan, maxAmountToCarry);
            AddEffect(resource.ToString(), ModificationType.Add, amountToHarvest);
            AddTargetEffect(resource.ToString(), ModificationType.Add, -amountToHarvest);
			AddTargetPrecondition(resource.ToString(), CompareType.MoreThanOrEqual, 1);
        }

        protected void Start() {
			RefreshTargets ();
        }

		private void RefreshTargets(){
			if (fromBros) {
				targets = GetTargets<BroForReal>();
			}
			else {
				targets = GetTargets<Weed>();
			}
		}
    
        public override bool RequiresInRange() {
            return true;
        }

        public override List<IStateful> GetAllTargets(GoapAgent agent) {
			// Refresh list
			RefreshTargets();
            return targets;
        }

        protected override bool OnDone(GoapAgent agent, WithContext context) {

			//destroy plant if finished
			Weed weed = context.target as Weed; 

            var backpack = agent.GetComponent<Container>();
            backpack.items[resource] += amountToHarvest;

			if (fromBros) {
				var bro = context.target as BroForReal;
				Container broBag = bro.GetComponent<Container> ();
				broBag.items [resource] -= amountToHarvest;
			} else if (weed != null && weed.ToString() != "Null" && weed.ToString() != "null") {
				weed.amount -= amountToHarvest;
				if (weed.amount <= 0) {
					GameObject weedObj = weed.gameObject; 
					Destroy (weedObj);
				}
			}
			// Refresh list
			RefreshTargets();

            return base.OnDone(agent, context);
        }
    }
}