using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using UnityEngine;

namespace ScoredProductions.ScoredsBT.Version4 {
	[ExecuteInEditMode]
	public class MonoBTRoot : MonoBehaviour {

		public bool Running = false; // Value exposed to the inspector.

		private bool _tasksRunning = false;

		private bool LoadedOperation = false; // Loading the trees is expensive so it is done once at the start of the operation.
		public List<MonoNodeBase> Trees = new List<MonoNodeBase>(); // Now incorperates multiple trees instead of using the first found.

		// List of Task to store the Routines, just starting a Routine would mean we cant get results from them.
		private List<Task> RunningRoutines = new List<Task>();

		private void Update() {
			if (Running) {
				if (_tasksRunning == false) {
					_tasksRunning = true;
					RunningRoutines = new List<Task>();

					if (!LoadedOperation) { // Set to false after each run
						LoadedOperation = LoadTrees();
					}

					if (LoadedOperation) {
						foreach (MonoNodeBase Tree in Trees) {
							Task task = Tree.Execute();
							task.ConfigureAwait(false);
							RunningRoutines.Add(task);
						}

						// Not awaiting this and including ".ConfigureAwait(false)" allows the task to be fired and forgotton onto a thread
						Task.Run(async () => await Task.WhenAll(RunningRoutines).ContinueWith(e => {
							_tasksRunning = false;
						})).ConfigureAwait(false);
					}
				}
			} else {
				LoadedOperation = false; // Only toggles off once Running is off.
			}
		}

		private bool LoadTrees() {
			Trees.Clear();
			foreach (Transform child in transform) {
				MonoNodeBase script = child.GetComponent<MonoNodeBase>();
				if (script != null) {
					Trees.Add(script);
				}
			}
			return Trees.Count > 0; // Will toggle Loaded on only when a tree has been found.
		}
	}
}