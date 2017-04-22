using System.Collections.Generic;
using Ai.Goap;
using UnityEngine;
using System;

namespace TeamFirewood {
public class DropOffItemAction : GoapAction {
    public Item itemToDrop;
    private List<IStateful> targets;

    protected void Awake() {
        // TODO: Add a way to reference target state values in effects. For
        //       example, add all of the agent's items to the state of the
        //       target or vice versa, or take up to a certain amount.
        AddPrecondition(itemToDrop.ToString(), CompareType.MoreThanOrEqual, 1);
        AddEffect(itemToDrop.ToString(), ModificationType.Add, -1);
		AddEffect("create" + itemToDrop.ToString(), ModificationType.Set, true);
        AddTargetEffect(itemToDrop.ToString(), ModificationType.Add, 1);
		AddTargetEffect("friendIsHappy", ModificationType.Set, true);
    }

    protected void Start() {
			targets = GetTargets<Sofa>();
    }

    public override bool RequiresInRange() {
        return true;
    }

    public override List<IStateful> GetAllTargets(GoapAgent agent) {
        return targets;
    }

    protected override bool OnDone(GoapAgent agent, WithContext context) {
        var backpack = agent.GetComponent<Container>();
		var target = context.target as Sofa;
        ++target.GetComponent<Container>().items[itemToDrop];
        --backpack.items[itemToDrop];
        
        return base.OnDone(agent, context);
    }
}
}
