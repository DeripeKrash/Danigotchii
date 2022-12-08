
# Features:
## Blackboard:

DaniGotchii is a student Unity project made to learn how to build and customize an Utility System IA. The project had for purpose to create a reproduction of a Tamagotchii with fully customizable personnality and needs in editor.

<div align="center">
    <p></p>
    <img src="Screenshots/DaniGotchii_Gameplay1.png" width=60% height=60%/>
    <img src="Screenshots/DaniGotchii_Gameplay2.png" width=49% height=49%/>
    <img src="Screenshots/DaniGotchii_Gameplay3.png" width=49% height=49%/>
</div>

The parameters used for the customization and IA setting of the DaniGotchii are set in a Blackboard component in which you can set a list of variables with a name and a float value.

<div align="center">
    <p></p>
<img src="Screenshots/Blackboard.png" width=60% height=60% /> 
</div>

## DaniGotchii

You can set a list of needs for the DaniGotchii and you can set the duration needed for the value to reach 1. They must have the same name as the value in the blackboard for the IA to access these Data. The Danigotchii component will update those value in runtime decreasing or increasing them.

<div align="center">
    <p></p>
<img src="Screenshots/DaniGotchii.png" width=60% height=60% />
</div>

## DaniGotchii Interaction Manager

You can interact with the needs of a Danigotchii with the helps of an interaction Manager. it allows to create a list of interaction that can fill the needs of the DaniGotchii. The player can interact with the DaniGotchii with dropdowns to select the function, and click on the button associate to call the function.

<div align="center">
    <p></p>
<img src="Screenshots/DaniGotchiiInteractionManager.png" width=60% height=60% />
</div>

The InteractButton component is a UI object that takes an InteractionManager as parameters and allow to call the interaction created in it.

<div align="center">
    <p></p>
<img src="Screenshots/InteractButtons.png" width=60% height=60% />
</div>

## Status

Indicate the current value of the needs.

<div align="center">
    <p></p>
<img src="Screenshots/Bars.png" width=60% height=60% />
</div>

## Utility System

The Utility system works with a AI_UtilitySystem component and AI_UtilityState

<div align="center">
    <p></p>
<img src="Screenshots/Hierachy_IA.png" width=60% height=60% />
<img src="Screenshots/UtilitySystem.png" width=60% height=60% />
</div>


The AI_UtilitySystem works by selecting the AI_UtilityState that has the higher priority.
The AI_UtilityState that must be inherited to set the priority calcul and function to do while the state is active.

The UtilityState is override with AI_UtilityStateBlackboard which use a variable in the blackboard and a graph function to determine the priority.
It also use events to call functions when the state is setup and while it's used.

<div align="center">
    <p></p>
<img src="Screenshots/UtilityStateBlackboard.png" width=60% height=60% />
</div>

 ## Math function

The Utility system use several mathematical function to determine the current state :

- Linear
- Exponential
- Sigmoid
- Logistic
- logarithmic
- AnimationCurve

Those function are located in GraphFunction.cs


## Credit
- FIGEIREDO Alex
- PETIT Denis
