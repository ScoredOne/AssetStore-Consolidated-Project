using System.Threading.Tasks;

namespace ScoredProductions.ScoredsBT.Version4 {
	public class MonoLeafChildB : MonoLeaf {

		protected override async Task<bool> Leaf_Function() { // Warning CS1998, awaits are not required but this version supports them for leafs
			return false;
		}
	}
}
// Made to show what happens on a blank leaf.