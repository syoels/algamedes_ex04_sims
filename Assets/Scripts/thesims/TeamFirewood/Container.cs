using UnityEngine;
using System.Collections.Generic;
using Infra.Utils;

namespace TeamFirewood {
public enum Item {
    None,
    Logs,
    Firewood,
    Ore,
    Branches,
    Water,
	Weed,
	Candy
}

/// <summary>
/// Backpack that holds a tool and resources.
/// </summary>
    public class Container : MonoBehaviour {
        // TODO: Add each tool as a specific item. Have the blacksmith craft each
        //       tool separately. One goal per tool.
        // TODO: Allow changing the priorities of the blacksmith's goals.
        public Dictionary<Item, int> items = new Dictionary<Item, int> {
            {Item.Logs, 0},
            {Item.Firewood, 0},
            {Item.Ore, 0},
            {Item.Branches, 0},
            {Item.Water, 0},
			{Item.Weed, 0},
			{Item.Candy, 0}
        };

        [SerializeField]
        protected int newTools;
        [SerializeField]
        protected int logs;
        [SerializeField]
        protected int firewood;
        [SerializeField]
        protected int ore;
        [SerializeField]
        protected int branches;
        [SerializeField]
        protected int water;
		[SerializeField]
		protected int weed;
		[SerializeField]
		protected int candy;

            protected void Awake() {
            // Make sure all new items are defined in the container.
            foreach (var item in EnumUtils.EnumValues<Item>()) {
                if (item == Item.None) continue;
                items[item] = 0;
            }
            items[Item.Logs] = logs;
            items[Item.Firewood] = firewood;
            items[Item.Ore] = ore;
            items[Item.Branches] = branches;
            items[Item.Water] = water;
			items[Item.Weed] = weed;
			items[Item.Candy] = candy;
        }

    #if DEBUG_CONTAINER
        protected void Update() {
            logs = items[Item.Logs];
            firewood = items[Item.Firewood];
            ore = items[Item.Ore];
            branches = items[Item.Branches];
            branches = items[Item.Water];
			weed = items[Item.Weed];
			candy = items[Item.Candy];
        }
    #endif
    }
}
