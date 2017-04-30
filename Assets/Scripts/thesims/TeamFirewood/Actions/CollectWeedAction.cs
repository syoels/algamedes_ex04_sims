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
            if (fromBros) {
                targets = GetTargets<BroForReal>();
				Debug.Log ("Collecting from Bros. found " + targets.Count.ToString() + " Bros.");
            }
            else {
                targets = GetTargets<Weed>();
            }
        }
    
        public override bool RequiresInRange() {
            return true;
        }

        public override List<IStateful> GetAllTargets(GoapAgent agent) {
            return targets;
        }

        protected override bool OnDone(GoapAgent agent, WithContext context) {
            // Done harvesting.
            var backpack = agent.GetComponent<Container>();
            backpack.items[resource] += amountToHarvest;

			if (fromBros) {
				var bro = context.target as BroForReal;
				Container broBag = bro.GetComponent<Container> ();
				broBag.items[resource] -= amountToHarvest;
			}


            return base.OnDone(agent, context);
        }
    }
}