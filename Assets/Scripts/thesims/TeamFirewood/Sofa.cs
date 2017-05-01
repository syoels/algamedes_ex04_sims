using UnityEngine;
using Infra.Utils;
using Ai.Goap;

namespace TeamFirewood {
public class Sofa : PointOfInterest {
		public UnityEngine.UI.Text text; 
		private Container bag; 
		private int weedAmount = 0; 

		void Awake(){
			bag = GetComponent<Container> ();
		}

		void Update(){
			int currentAmount = bag.items [Item.Weed];
			if (currentAmount != weedAmount) {
				weedAmount = currentAmount; 
				text.text = "Weed Delivered: " + weedAmount.ToString();
			}
		}


    
}
}
