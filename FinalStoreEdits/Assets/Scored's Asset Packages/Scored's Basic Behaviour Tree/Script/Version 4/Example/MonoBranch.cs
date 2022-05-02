using System.Collections.Generic;
using System.Threading.Tasks;

using UnityEngine;

namespace ScoredProductions.ScoredsBT.Version4 {
	public abstract class MonoBranch : MonoNodeBase {

		protected Task CurrentRunningBranch;

		protected List<MonoNodeBase> NodeList; // Nodes to execute

		protected void Start() { // default Start() that is called in the branches 
			NodeList = new List<MonoNodeBase>();
			Refresh(true);
		}

		protected void Refresh(bool force) {
			if (!force && NodeList.Count != transform.childCount) {
				return;
			}
			NodeList.Clear();
			foreach (Transform child in transform) {
				MonoNodeBase script = child.GetComponent<MonoNodeBase>();
				if (script != null) {
					NodeList.Add(script);
				}
			}
		}
	}
}