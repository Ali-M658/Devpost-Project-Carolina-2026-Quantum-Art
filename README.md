# The Quantum Phase Manifold

An exploration of deterministic quantum synthesis, mapping entangled qubit states to complex geometric manifolds. This project bridges the gap between quantum computation and generative art by using phase interference to modulate spatial coordinate transformations.

## Technical Overview

The project utilizes a hybrid quantum-classical architecture to generate high-resolution visualizations of mathematical manifolds.

### 1. Quantum Phase Extraction (Q#)
The quantum kernel initializes a 4-qubit register in a superposition state. Through the application of Entanglement operators (CNOT), I generate a set of correlated phase anchors:
$$\theta_n \in \{0, \frac{\pi}{2}, \frac{\pi}{4}, \frac{\pi}{8}\}$$

### 2. Trigonometric Coordinate Transformation (C#)
Instead of using a static initial constant $c$, I define a spatial transformation function $F(x, y)$ that modulates the complex plane based on the quantum phases:
$$c_x = \sin(x + \theta_0) \cdot \cos(y + \theta_1)$$
$$c_y = \cos(x + \theta_2) \cdot \sin(y + \theta_3)$$

### 3. Complex Quadratic Map
Every pixel undergoes a non-linear iteration until it reaches a divergence threshold or the maximum iteration count:
$$z_{n+1} = z_n^2 + (c_x + i c_y)$$

## Project Structure

- **QuantumEchoGarden.qs**: The Q# kernel managing qubit entanglement and phase measurement.
- **Program.cs**: The C# rendering engine using SkiaSharp for high-performance visual synthesis.
- **quantum_manifold_render.png**: The generated manifold visualization.

## Setup and Execution

### Prerequisites
- .NET SDK (Compatible with Microsoft.Quantum.Sdk 0.28.x)
- [SkiaSharp](https://github.com/mono/SkiaSharp) library
- [Microsoft Quantum Development Kit](https://azure.microsoft.com/en-us/resources/development-kit/quantum/)

### Build and Run
1. Clone the repository.
2. Ensure SkiaSharp is restored via NuGet.
3. Execute the following commands in the project root:
```bash
dotnet build
dotnet run
