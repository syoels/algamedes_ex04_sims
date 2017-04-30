using UnityEngine;
using Infra.Utils;
using Ai.Goap;

namespace TeamFirewood {
/// <summary>
/// A point of interest where resources can be collected.
/// </summary>
[RequireComponent(typeof(Container))]
public class HarvestPoint : PointOfInterest {
    private Container container;
    private readonly State worldData = new State();

    protected void Awake() {
        container = GetComponent<Container>();
    }

    protected void Start() {
        foreach (var item in EnumUtils.EnumValues<Item>()) {
            if (item == Item.None) continue;
            worldData[item.ToString()] = new StateValue(container.items[item]);
        }
    }

    public override State GetState() {
        foreach (var item in EnumUtils.EnumValues<Item>()) {
            if (item == Item.None) continue;
            worldData[item.ToString()].value = container.items[item];
        }

        return worldData;
    }
}
}
