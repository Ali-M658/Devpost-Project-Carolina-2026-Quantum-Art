namespace QuantumEchoGarden {
    open Microsoft.Quantum.Intrinsic;
    open Microsoft.Quantum.Math;
    open Microsoft.Quantum.Measurement;

    operation GetQuantumPhases() : Double[] {
        use qubits = Qubit[4];
        
        H(qubits[0]);
        H(qubits[1]);
        CNOT(qubits[0], qubits[2]);
        CNOT(qubits[1], qubits[3]);

        // Declare mutables to avoid ternary syntax errors
        mutable p0 = 0.0;
        mutable p1 = 0.0;
        mutable p2 = 0.0;
        mutable p3 = 0.0;

        // Use explicit if-statements
        if (MResetZ(qubits[0]) == One) { 
            set p0 = PI() / 2.0; 
        }
        if (MResetZ(qubits[1]) == One) { 
            set p1 = PI() / 2.0; 
        }
        if (MResetZ(qubits[2]) == One) { 
            set p2 = PI() / 4.0; 
        }
        if (MResetZ(qubits[3]) == One) { 
            set p3 = PI() / 8.0; 
        }

        return [p0, p1, p2, p3];
    }
}