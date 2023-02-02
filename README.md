FeatureSystem

It's simple but powerful framework for easy prototyping games of any genre

How to use:

1 Add scripts Features and GameSystems to empty object on scene;

2 Create your feature script inherited from Feature;

3 Feature has Initialize method where you can create Systems (inherited from ISystem, ISystemUpdate)
  and register them in GameSystems by calling GameSystem.RegisterSystem();
  
4 You can get access to any system by calling GameSystem.GetSystem<T> 
  (NOTE: In other systems use it at Initialization method, not at constructor);

5 Create feature asset (use CreateAssetMenu atribute on feature script);

6 Add feature assets in Features array;

7 Call Features.InitializeFeaturesAndSystems() when your game starts;

8 Call GameSystems.DestroySystems() when your game ends
