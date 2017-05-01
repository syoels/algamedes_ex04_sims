using UnityEngine;
using Infra.Utils;
using Ai.Goap;

namespace TeamFirewood {
public class Candy : PointOfInterest {
    
    private readonly State state = new State();
	public int amount = 10; 

    protected void Awake() {
			state [Item.Candy.ToString()] = new StateValue (amount);
    }

    public override State GetState() {
        // Enable to check again if has branches.
        enabled = true;
        return state;
    }
}
}
