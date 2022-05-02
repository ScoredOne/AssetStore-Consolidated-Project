using System.Collections.Generic;
using System.Threading.Tasks;

using UnityEngine;

namespace ScoredProductions.ScoredsBT.Version4 {
	public class MonoLeafChildA : MonoLeaf {

		protected override async Task<bool> Leaf_Function() { // Warning CS1998, awaits are not required but this version supports them for leafs
			Debug.Log("Child A Successfully triggered");
			return true;
		}
	}
}
// Example Leaf Child.