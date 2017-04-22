using UnityEngine;
using Infra.Utils;
using Ai.Goap;

namespace TeamFirewood {
public class Weed : PointOfInterest {
    [Range(0f, 1f)]
    [SerializeField] float chanceToHaveBranches = 1f;
    private readonly State state = new State();

    protected void Awake() {
			state["has" + Item.Weed] =
            new StateValue(RandomUtils.RandBool(chanceToHaveBranches));
    }

    public override State GetState() {
        // Enable to check again if has branches.
        enabled = true;
        return state;
    }

    protected void Update() {
			state["has" + Item.Weed].value =
            RandomUtils.RandBool(chanceToHaveBranches);
        enabled = false;
    }
}
}
