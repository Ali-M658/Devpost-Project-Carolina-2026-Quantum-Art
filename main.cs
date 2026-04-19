using System;
using System.IO;
using SkiaSharp;
using Microsoft.Quantum.Simulation.Simulators;
using QuantumEchoGarden;

class Program {
    static void Main() {
        const int size = 1000;
        using var qsim = new QuantumSimulator();
        using var bitmap = new SKBitmap(size, size);
        
        // Retrieve the quantum phase shifts
        var qArrayResult = GetQuantumPhases.Run(qsim).Result;
        double[] qPhases = new double[qArrayResult.Length];
        for (int i = 0; i < qArrayResult.Length; i++) {
            qPhases[i] = qArrayResult[i];
        }

        Console.WriteLine("Rendering Quantum Biomorph Field...");

        for (int y = 0; y < size; y++) {
            for (int x = 0; x < size; x++) {
                // Normalize coordinates (-2.5 to 2.5)
                double zx = (x / (double)size) * 5.0 - 2.5;
                double zy = (y / (double)size) * 5.0 - 2.5;

                // Quantum-Interfered Initial State
                // The qubits determine the starting "Vibration" of the pixel
                double cx = Math.Sin(zx + qPhases[0]) * Math.Cos(zy + qPhases[1]);
                double cy = Math.Cos(zx + qPhases[2]) * Math.Sin(zy + qPhases[3]);

                int i;
                for (i = 0; i < 50; i++) {
                    double xtemp = zx * zx - zy * zy + cx;
                    zy = 2.0 * zx * zy + cy;
                    zx = xtemp;

                    // BIOMORPH CONDITION: Check if Real or Imaginary part escapes
                    // This creates the "organism" or "crystalline" look
                    if (Math.Abs(zx) > 10 || Math.Abs(zy) > 10) break;
                }

                // Color based on the escape logic
                SKColor color;
                if (i == 50) {
                    color = SKColors.Black; 
                } else {
                    // Map the final position to a vibrant spectral color
                    float hue = (float)(Math.Atan2(zy, zx) * 180 / Math.PI) + 180f;
                    color = SKColor.FromHsv(hue, 80, 100);
                }
                bitmap.SetPixel(x, y, color);
            }
        }

        using var image = SKImage.FromBitmap(bitmap);
        using var data = image.Encode(SKEncodedImageFormat.Png, 100);
        using var stream = File.OpenWrite("quantum_biomorph.png");
        data.SaveTo(stream);
        
        Console.WriteLine("Success! 'quantum_biomorph.png' generated.");
    }
}