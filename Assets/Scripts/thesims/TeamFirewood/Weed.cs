using UnityEngine;
using Infra.Utils;
using Ai.Goap;

namespace TeamFirewood {
public class Weed : PointOfInterest {
    [Range(0f, 1f)]
    [SerializeField] float chancesToHaveWeed = 1f;
    private readonly State state = new State();
		public int amount = 10; 

    protected void Awake() {
			bool hasWeed = RandomUtils.RandBool (chancesToHaveWeed);
			if (hasWeed) {
				state [Item.Weed.ToString()] = new StateValue (amount);
			} else {
				state [Item.Weed.ToString()] = new StateValue (0);
			}
    }

    public override State GetState() {
        // Enable to check again if has branches.
        enabled = true;
        return state;
    }
	
    protected void Update() {
			if (RandomUtils.RandBool (chancesToHaveWeed)) {
				state [Item.Weed.ToString()] = new StateValue (amount);
			} else {
				state[Item.Weed.ToString()].value = 0;
			}

        enabled = false;
    }
}
}
