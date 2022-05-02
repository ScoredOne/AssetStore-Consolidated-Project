Created by Duncan "ScoredOne" Mellor.
@ScoredOne scoredone1994@gmail.com

Hi, thanks for downloading this project.
Included is 4 versions of the behaviour tree I created over time.

For main deployment please use version 3 or version 4.
Version 3 for coroutines or version 4 for await/async.

Versions 1 and 2, I created as proof of concept versions of the project with version 3 using coroutines and acting as the first main version.
Version 4 being the final version added in a later update.

#HowTo:
- The code is commented with instructions but a quick guide to the types is here.

- The scenes are preloaded with basic stuctures of both types.

- The structure of the scripts is:
	-	Sequence
	--	Sequence		-			Selector
	--- LeafA - LeafA - LeafA	|	LeafB - LeafB - LeafC

- The output will be produced in the console and should show:
	- 3 => "Child A Successfully triggered"
	- Followed by a 0-100 count.
(V4)- Followed by "Child C Completed Successfully".

- To run the trees, toggle the Running bool to on, even in Editor mode. They will work continuously until turned off.

- The Monobehaviour versions works by including the scripts onto GameObjects and placing the GameObjects under respective GameOjects
  of the tree.

- (Version 1 and 2) The ScriptableObject version requires the tree to be programaticly created.

#Notes:

- The Unity Engine (in 2019, I dont know for other versions) will NOT distinguish code of the same name in the inspector by
  its 'namespace' so please be carefull when looking between versions. It will still run them seperatly or by mixing them but it wont say which version
  its using.

- Best practice for if you wish to copy a version to make a amendments is to copy the entire version folder and to go into
  each CS file and change the namespace name of each file.

- The namespace of the project is 'ScoredProductions.ScoredsBT.' and is currently using Version1, Version2, Version3 and Version4
  so please avoid using the same namespace.