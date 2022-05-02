using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScoredProductions.ScoredsBT.Version4 {
	public sealed class MonoSelector : MonoBranch {

		public override async Task Execute() {
			Refresh(false); // Instead of having the check in update, the check is now performed before executing
			Running = true;
			NodeSuccess = false;
			foreach (MonoNodeBase node in NodeList) {
				await node.Execute(); // complexities from coroutines removed as its all managed by await now

				if (node.NodeSuccess) { // Once the first node Succeeds, we dont need to continue so return the result
					NodeSuccess = true;
					break;
				}
			}
			Running = false;
		}
	}
}