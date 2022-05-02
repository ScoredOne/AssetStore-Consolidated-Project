using System.Threading.Tasks;

using UnityEngine;

namespace ScoredProductions.ScoredsBT.Version4 {
	public class MonoLeafChildC : MonoLeaf {

		private int count = 0;

		protected override async Task<bool> Leaf_Function() { // Warning CS1998, awaits are not required but this version supports them for leafs
			if (count < 100) { // counts up to 100, keeps the leaf on and running until its done for example.
				Debug.Log(++count);
				return false;
			} else {
				count = 0;
				Debug.Log("Child C Completed Successfully");
				return true;
			}
		}
	}
}

// This is an example of a leaf node that requires running to stay true until it is complete.
// When it is finished the return value can be changed to true.