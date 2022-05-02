using System.Collections.Generic;
using System.Threading.Tasks;

using UnityEngine;

namespace ScoredProductions.ScoredsBT.Version4 {
	public abstract class MonoLeaf : MonoNodeBase {

		[Range(1, 10000)] // limits the inspector values.
		[Tooltip("Amount of attempts a leaf will execute before failing.")] // inspector message
		public int SafetyValue = 1000; // Value exposed to the Inspector.

		[Range(0, 10000)]
		[Tooltip("Delay between execute attempts.")]
		public int SafetyDelay = 10;

		public sealed override async Task Execute() {
			int safety = 0;
			bool returned = false;

			Running = true;

			// performs the task of the leaf function until completion or safety triggered
			await Task.Run(async () => {
				while ((returned = await Leaf_Function()) == false && ++safety <= SafetyValue) {
					if (SafetyDelay > 0) {
						await Task.Delay(SafetyDelay);
					}
				}
			});

			NodeSuccess = returned;
			Running = false;

			if (safety >= SafetyValue) { // Kept to maintain a time based safety
				Debug.LogWarning(gameObject.name + " : Safety catch triggered"); // Safety shouldnt be triggered, although caught it should never get here.
			}
		}

		protected abstract Task<bool> Leaf_Function(); // Class that must be implemented in child classes, functionality is now all placed in here removing delegates.
	}
}
// You can make children based from the leaf class to simplify and organise the functions. ("LeafChildA", "LeafChildB")
