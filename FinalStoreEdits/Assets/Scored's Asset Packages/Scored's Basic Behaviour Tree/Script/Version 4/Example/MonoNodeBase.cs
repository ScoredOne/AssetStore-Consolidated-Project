using System.Collections.Generic;
using System.Threading.Tasks;

using UnityEngine;

namespace ScoredProductions.ScoredsBT.Version4 {
	[ExecuteInEditMode]
	public abstract class MonoNodeBase : MonoBehaviour {
		public abstract Task Execute(); // Function thats called in all classes.

		public bool Running { get; protected set; }

		public bool NodeSuccess { get; protected set; }
	}
}
// Base class of branches and leafs.