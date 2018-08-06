// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace myShorLib {
    open Microsoft.Quantum.Primitive;
    open Microsoft.Quantum.Canon;

    operation PhaseEstimation(
        x : Int, 
        N : Int, 
        precision : Int) : Int
    {
        body
        {
            let eigenLength = BitSize(N);
            mutable res = 0;

            using (eigenvector = Qubit[eigenLength]){
                X(eigenvector[0]);
                
                using (target = Qubit[precision]){
                    
                    PhaseEstimationImpl(x, N, target, eigenvector);
                    
                    for (i in 0..(precision - 1)) {
                        set res = res * 2;
                        if (M(target[i]) == One) {
                            set res = res + 1;
                        }
                    }
                    ResetAll(target);
                    ResetAll(eigenvector);
                }
            }
        
            return res;
        }
    }

    operation PhaseEstimationImpl (
        x : Int,
        N : Int,
        target : Qubit[],
        eigenvector : Qubit[]) : ()
    {
        body {
            let targetLength = Length(target);

            for (idx in 0..(targetLength - 1)) {
                H(target[idx]);
            }

            mutable power = 1;
            for (idx in 0..(targetLength - 1)) {
                (Controlled ConstructU) ([target[targetLength - 1 -idx]], (x, N, power, eigenvector)); 
                set power = power * 2;
            }
            
            (InverseFT)(target);
            // (Adjoint QFT)(BigEndian(target));
        }
    }

    operation ConstructU(
        x : Int,
        modulus : Int, 
        power : Int, 
        target : Qubit[]) : ()
    {
        body {
            ModularMultiplyByConstantLE(
                PowerMod(x, power, modulus), 
                modulus,
                LittleEndian(target)
            ); 
        }
        adjoint auto

        controlled auto
        adjoint controlled auto 
    }


    operation InverseFT(qs : Qubit[]) : () 
    {
        body {
            let qLength = Length(qs);
            for (i in 0..(qLength - 1)) {
                for (j in 0..(i-1)) {
                    (Controlled R1Frac) ([qs[j]], (1, i - j, qs[i]));
                }
                H(qs[i]);
            }
           
            for (i in 0..qLength/2-1) {
                SWAP(qs[i],qs[qLength-1-i]);
            }

        }
        adjoint auto
        controlled auto
        controlled adjoint auto
    }

    function PowerMod(
        x : Int, 
        power : Int, 
        modulus : Int) : Int 
    {
        mutable times = x;
        mutable result = 1;
        mutable powerBits = power;

        // Fast Power
        let powerLength = BitSize(power);
        for (i in 0 .. powerLength-1) {
            if (powerBits % 2 == 1) {
                set result = result * times % modulus;
            }
            set powerBits = powerBits / 2;
            set times = times * times % modulus;
        }
        return result % modulus;
    }
   
    operation MyTest() : Int
    {
        body {
            let a = PhaseEstimation(3, 5, 7);
            return a;
        }
    }

}
