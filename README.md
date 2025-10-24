# Lee's Algorithm Illustration

A visual demonstration of Lee's Algorithm implemented in C# Windows Forms. This project provides an interactive way to understand pathfinding in a maze-like environment.

## Overview

This application demonstrates Lee's Algorithm, a pathfinding algorithm that guarantees finding the shortest path between two points in a maze. The program visualizes the process of finding a path from a starting point to a target (cheese) while avoiding obstacles.

## Features

- Interactive grid-based interface
- Visual representation of:
  - Start position
  - Target position (cheese)
  - Obstacles
  - Path finding process
  - Shortest path visualization
- Custom color scheme for better visibility
- Reset functionality to try different configurations

## Technical Details

- Built with C# and Windows Forms
- Uses a queue-based implementation of Lee's Algorithm
- Supports dynamic maze creation through user interaction
- Custom color schemes for better visualization

## How to Use

1. Run the application
2. Click on the grid to set:
   - Starting position
   - Target position (cheese)
   - Obstacles
3. Watch the algorithm find the shortest path
4. Use the reset button to try different configurations

## Requirements

- .NET 6.0 or higher
- Windows OS

## Build and Run

1. Clone the repository
2. Open `Soarece.sln` in Visual Studio
3. Build and run the project

## Implementation Details

The project implements Lee's Algorithm using:

- Queue-based breadth-first search
- Grid-based movement in four directions
- Dynamic obstacle placement
- Real-time path visualization

## License

This project is open source and available under the MIT License.
