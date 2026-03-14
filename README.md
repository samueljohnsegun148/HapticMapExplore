# HapticMapExplore

Explore Digital Maps with Haptic Feedback in Unity

## Overview
HapticMapExplore is a Unity project that enables users to interact with digital maps using haptic devices. By integrating the Haply hAPI, this project provides force feedback and tactile sensations, enhancing the experience of map exploration for research, accessibility, and interactive applications.

## Features
- **Haptic Device Integration:** Supports Haply hAPI for real-time force feedback.
- **Custom Device Control:** Scripts for end effector and pantograph device management.
- **Force Feedback Algorithms:** Modular handlers for 2D and 3D haptic feedback.
- **Configurable Parameters:** Easily adjust device, feedback, and scaling settings.
- **Sample Scene:** Ready-to-use Unity scene for quick testing and demonstration.

## Folder Structure
```
ApticMapExplor/
	Assets/
		Scripts/
			DeviceHaptic/      # End effector and slave handler scripts
			HapticForceFeedback/ # Feedback and pantograph logic
			Config/             # Device configuration storage
			Utils/              # Vector math extensions
		Haply hAPI/           # Haply hAPI Unity package
		Scenes/               # Sample Unity scenes
	ProjectSettings/        # Unity project settings
	Packages/               # Unity package manifest
```

## Getting Started
1. **Requirements:**
	 - Unity 2020.2 or later
	 - Haply hAPI-compatible haptic device
2. **Clone this repository** and open the `ApticMapExplor` folder in Unity.
3. **Connect your haptic device** and configure the port and parameters in the Unity Inspector.
4. **Open the Sample Scene** in `Assets/Scenes/SampleScene.unity`.
5. **Play the scene** to start exploring the map with haptic feedback.

## Credits
- [Haply Robotics, Inc.](https://2diy.haply.co/) for the hAPI Unity integration
- Project contributors and open-source community

## License
See [LICENSE](../LICENSE) for details.
