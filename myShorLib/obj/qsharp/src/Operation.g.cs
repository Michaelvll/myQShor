#pragma warning disable 1591
using System;
using Microsoft.Quantum.Primitive;
using Microsoft.Quantum.Simulation.Core;
using Microsoft.Quantum.MetaData.Attributes;

[assembly: OperationDeclaration("myShorLib", "PhaseEstimation (x : Int, N : Int, precision : Int) : Int", new string[] { }, "C:\\AResource\\QuantumComputing\\myShor\\myShorLib\\Operation.qs", 294L, 12L, 5L)]
[assembly: OperationDeclaration("myShorLib", "PhaseEstimationImpl (x : Int, N : Int, target : Qubit[], eigenvector : Qubit[]) : ()", new string[] { }, "C:\\AResource\\QuantumComputing\\myShor\\myShorLib\\Operation.qs", 1198L, 45L, 5L)]
[assembly: OperationDeclaration("myShorLib", "ConstructU (x : Int, modulus : Int, power : Int, target : Qubit[]) : ()", new string[] { "Controlled", "Adjoint" }, "C:\\AResource\\QuantumComputing\\myShor\\myShorLib\\Operation.qs", 1832L, 69L, 5L)]
[assembly: OperationDeclaration("myShorLib", "InverseFT (qs : Qubit[]) : ()", new string[] { "Controlled", "Adjoint" }, "C:\\AResource\\QuantumComputing\\myShor\\myShorLib\\Operation.qs", 2159L, 85L, 5L)]
[assembly: OperationDeclaration("myShorLib", "MyTest () : Int", new string[] { }, "C:\\AResource\\QuantumComputing\\myShor\\myShorLib\\Operation.qs", 3207L, 127L, 5L)]
[assembly: FunctionDeclaration("myShorLib", "PowerMod (x : Int, power : Int, modulus : Int) : Int", new string[] { }, "C:\\AResource\\QuantumComputing\\myShor\\myShorLib\\Operation.qs", 2641L, 105L, 14L)]
#line hidden
namespace myShorLib
{
    public class PhaseEstimation : Operation<(Int64,Int64,Int64), Int64>, ICallable
    {
        public PhaseEstimation(IOperationFactory m) : base(m)
        {
        }

        public class In : QTuple<(Int64,Int64,Int64)>, IApplyData
        {
            public In((Int64,Int64,Int64) data) : base(data)
            {
            }

            System.Collections.Generic.IEnumerable<Qubit> IApplyData.Qubits => null;
        }

        String ICallable.Name => "PhaseEstimation";
        String ICallable.FullName => "myShorLib.PhaseEstimation";
        protected Allocate Allocate
        {
            get;
            set;
        }

        protected ICallable<Int64, Int64> MicrosoftQuantumCanonBitSize
        {
            get;
            set;
        }

        protected ICallable<Qubit, Result> M
        {
            get;
            set;
        }

        protected ICallable<(Int64,Int64,QArray<Qubit>,QArray<Qubit>), QVoid> PhaseEstimationImpl
        {
            get;
            set;
        }

        protected Release Release
        {
            get;
            set;
        }

        protected ICallable<QArray<Qubit>, QVoid> ResetAll
        {
            get;
            set;
        }

        protected IUnitary<Qubit> MicrosoftQuantumPrimitiveX
        {
            get;
            set;
        }

        public override Func<(Int64,Int64,Int64), Int64> Body => (__in) =>
        {
            var (x,N,precision) = __in;
#line 15 "C:\\AResource\\QuantumComputing\\myShor\\myShorLib\\Operation.qs"
            var eigenLength = MicrosoftQuantumCanonBitSize.Apply(N);
#line 16 "C:\\AResource\\QuantumComputing\\myShor\\myShorLib\\Operation.qs"
            var res = 0L;
#line 18 "C:\\AResource\\QuantumComputing\\myShor\\myShorLib\\Operation.qs"
            var eigenvector = Allocate.Apply(eigenLength);
#line 19 "C:\\AResource\\QuantumComputing\\myShor\\myShorLib\\Operation.qs"
            MicrosoftQuantumPrimitiveX.Apply(eigenvector[0L]);
#line 21 "C:\\AResource\\QuantumComputing\\myShor\\myShorLib\\Operation.qs"
            var target = Allocate.Apply(precision);
#line 23 "C:\\AResource\\QuantumComputing\\myShor\\myShorLib\\Operation.qs"
            PhaseEstimationImpl.Apply((x, N, target, eigenvector));
#line 25 "C:\\AResource\\QuantumComputing\\myShor\\myShorLib\\Operation.qs"
            foreach (var i in new Range(0L, (precision - 1L)))
            {
#line 26 "C:\\AResource\\QuantumComputing\\myShor\\myShorLib\\Operation.qs"
                res = (res * 2L);
#line 27 "C:\\AResource\\QuantumComputing\\myShor\\myShorLib\\Operation.qs"
                if ((M.Apply(target[i]) == Result.One))
                {
#line 28 "C:\\AResource\\QuantumComputing\\myShor\\myShorLib\\Operation.qs"
                    res = (res + 1L);
                }
            }

#line 31 "C:\\AResource\\QuantumComputing\\myShor\\myShorLib\\Operation.qs"
            ResetAll.Apply(target);
#line 32 "C:\\AResource\\QuantumComputing\\myShor\\myShorLib\\Operation.qs"
            ResetAll.Apply(eigenvector);
#line hidden
            Release.Apply(target);
#line hidden
            Release.Apply(eigenvector);
#line 36 "C:\\AResource\\QuantumComputing\\myShor\\myShorLib\\Operation.qs"
            return res;
        }

        ;
        public override void Init()
        {
            this.Allocate = this.Factory.Get<Allocate>(typeof(Microsoft.Quantum.Primitive.Allocate));
            this.MicrosoftQuantumCanonBitSize = this.Factory.Get<ICallable<Int64, Int64>>(typeof(Microsoft.Quantum.Canon.BitSize));
            this.M = this.Factory.Get<ICallable<Qubit, Result>>(typeof(Microsoft.Quantum.Primitive.M));
            this.PhaseEstimationImpl = this.Factory.Get<ICallable<(Int64,Int64,QArray<Qubit>,QArray<Qubit>), QVoid>>(typeof(myShorLib.PhaseEstimationImpl));
            this.Release = this.Factory.Get<Release>(typeof(Microsoft.Quantum.Primitive.Release));
            this.ResetAll = this.Factory.Get<ICallable<QArray<Qubit>, QVoid>>(typeof(Microsoft.Quantum.Primitive.ResetAll));
            this.MicrosoftQuantumPrimitiveX = this.Factory.Get<IUnitary<Qubit>>(typeof(Microsoft.Quantum.Primitive.X));
        }

        public override IApplyData __dataIn((Int64,Int64,Int64) data) => new In(data);
        public override IApplyData __dataOut(Int64 data) => new QTuple<Int64>(data);
        public static System.Threading.Tasks.Task<Int64> Run(IOperationFactory __m__, Int64 x, Int64 N, Int64 precision)
        {
            return __m__.Run<PhaseEstimation, (Int64,Int64,Int64), Int64>((x, N, precision));
        }
    }

    public class PhaseEstimationImpl : Operation<(Int64,Int64,QArray<Qubit>,QArray<Qubit>), QVoid>, ICallable
    {
        public PhaseEstimationImpl(IOperationFactory m) : base(m)
        {
        }

        public class In : QTuple<(Int64,Int64,QArray<Qubit>,QArray<Qubit>)>, IApplyData
        {
            public In((Int64,Int64,QArray<Qubit>,QArray<Qubit>) data) : base(data)
            {
            }

            System.Collections.Generic.IEnumerable<Qubit> IApplyData.Qubits => Qubit.Concat(((IApplyData)Data.Item3)?.Qubits, ((IApplyData)Data.Item4)?.Qubits);
        }

        String ICallable.Name => "PhaseEstimationImpl";
        String ICallable.FullName => "myShorLib.PhaseEstimationImpl";
        protected IUnitary<(Int64,Int64,Int64,QArray<Qubit>)> ConstructU
        {
            get;
            set;
        }

        protected IUnitary<Qubit> MicrosoftQuantumPrimitiveH
        {
            get;
            set;
        }

        protected IUnitary<QArray<Qubit>> InverseFT
        {
            get;
            set;
        }

        public override Func<(Int64,Int64,QArray<Qubit>,QArray<Qubit>), QVoid> Body => (__in) =>
        {
            var (x,N,target,eigenvector) = __in;
#line 47 "C:\\AResource\\QuantumComputing\\myShor\\myShorLib\\Operation.qs"
            var targetLength = target.Count;
#line 49 "C:\\AResource\\QuantumComputing\\myShor\\myShorLib\\Operation.qs"
            foreach (var idx in new Range(0L, (targetLength - 1L)))
            {
#line 50 "C:\\AResource\\QuantumComputing\\myShor\\myShorLib\\Operation.qs"
                MicrosoftQuantumPrimitiveH.Apply(target[idx]);
            }

#line 53 "C:\\AResource\\QuantumComputing\\myShor\\myShorLib\\Operation.qs"
            var power = 1L;
#line 54 "C:\\AResource\\QuantumComputing\\myShor\\myShorLib\\Operation.qs"
            foreach (var idx in new Range(0L, (targetLength - 1L)))
            {
#line 55 "C:\\AResource\\QuantumComputing\\myShor\\myShorLib\\Operation.qs"
                ConstructU.Controlled.Apply((new QArray<Qubit>()
                {target[((targetLength - 1L) - idx)]}, (x, N, power, eigenvector)));
#line 56 "C:\\AResource\\QuantumComputing\\myShor\\myShorLib\\Operation.qs"
                power = (power * 2L);
            }

#line 59 "C:\\AResource\\QuantumComputing\\myShor\\myShorLib\\Operation.qs"
            InverseFT.Apply(target);
            // (Adjoint QFT)(BigEndian(target));
            ;
#line hidden
            return QVoid.Instance;
        }

        ;
        public override void Init()
        {
            this.ConstructU = this.Factory.Get<IUnitary<(Int64,Int64,Int64,QArray<Qubit>)>>(typeof(myShorLib.ConstructU));
            this.MicrosoftQuantumPrimitiveH = this.Factory.Get<IUnitary<Qubit>>(typeof(Microsoft.Quantum.Primitive.H));
            this.InverseFT = this.Factory.Get<IUnitary<QArray<Qubit>>>(typeof(myShorLib.InverseFT));
        }

        public override IApplyData __dataIn((Int64,Int64,QArray<Qubit>,QArray<Qubit>) data) => new In(data);
        public override IApplyData __dataOut(QVoid data) => data;
        public static System.Threading.Tasks.Task<QVoid> Run(IOperationFactory __m__, Int64 x, Int64 N, QArray<Qubit> target, QArray<Qubit> eigenvector)
        {
            return __m__.Run<PhaseEstimationImpl, (Int64,Int64,QArray<Qubit>,QArray<Qubit>), QVoid>((x, N, target, eigenvector));
        }
    }

    public class ConstructU : Unitary<(Int64,Int64,Int64,QArray<Qubit>)>, ICallable
    {
        public ConstructU(IOperationFactory m) : base(m)
        {
        }

        public class In : QTuple<(Int64,Int64,Int64,QArray<Qubit>)>, IApplyData
        {
            public In((Int64,Int64,Int64,QArray<Qubit>) data) : base(data)
            {
            }

            System.Collections.Generic.IEnumerable<Qubit> IApplyData.Qubits => ((IApplyData)Data.Item4)?.Qubits;
        }

        String ICallable.Name => "ConstructU";
        String ICallable.FullName => "myShorLib.ConstructU";
        protected IUnitary<(Int64,Int64,Microsoft.Quantum.Canon.LittleEndian)> MicrosoftQuantumCanonModularMultiplyByConstantLE
        {
            get;
            set;
        }

        protected ICallable<(Int64,Int64,Int64), Int64> PowerMod
        {
            get;
            set;
        }

        public override Func<(Int64,Int64,Int64,QArray<Qubit>), QVoid> Body => (__in) =>
        {
            var (x,modulus,power,target) = __in;
#line 71 "C:\\AResource\\QuantumComputing\\myShor\\myShorLib\\Operation.qs"
            MicrosoftQuantumCanonModularMultiplyByConstantLE.Apply((PowerMod.Apply((x, power, modulus)), modulus, new Microsoft.Quantum.Canon.LittleEndian(target)));
#line hidden
            return QVoid.Instance;
        }

        ;
        public override Func<(Int64,Int64,Int64,QArray<Qubit>), QVoid> AdjointBody => (__in) =>
        {
            var (x,modulus,power,target) = __in;
            MicrosoftQuantumCanonModularMultiplyByConstantLE.Adjoint.Apply((PowerMod.Apply((x, power, modulus)), modulus, new Microsoft.Quantum.Canon.LittleEndian(target)));
#line hidden
            return QVoid.Instance;
        }

        ;
        public override Func<(QArray<Qubit>,(Int64,Int64,Int64,QArray<Qubit>)), QVoid> ControlledBody => (__in) =>
        {
            var (controlQubits,(x,modulus,power,target)) = __in;
            MicrosoftQuantumCanonModularMultiplyByConstantLE.Controlled.Apply((controlQubits, (PowerMod.Apply((x, power, modulus)), modulus, new Microsoft.Quantum.Canon.LittleEndian(target))));
#line hidden
            return QVoid.Instance;
        }

        ;
        public override Func<(QArray<Qubit>,(Int64,Int64,Int64,QArray<Qubit>)), QVoid> ControlledAdjointBody => (__in) =>
        {
            var (controlQubits,(x,modulus,power,target)) = __in;
            MicrosoftQuantumCanonModularMultiplyByConstantLE.Adjoint.Controlled.Apply((controlQubits, (PowerMod.Apply((x, power, modulus)), modulus, new Microsoft.Quantum.Canon.LittleEndian(target))));
#line hidden
            return QVoid.Instance;
        }

        ;
        public override void Init()
        {
            this.MicrosoftQuantumCanonModularMultiplyByConstantLE = this.Factory.Get<IUnitary<(Int64,Int64,Microsoft.Quantum.Canon.LittleEndian)>>(typeof(Microsoft.Quantum.Canon.ModularMultiplyByConstantLE));
            this.PowerMod = this.Factory.Get<ICallable<(Int64,Int64,Int64), Int64>>(typeof(myShorLib.PowerMod));
        }

        public override IApplyData __dataIn((Int64,Int64,Int64,QArray<Qubit>) data) => new In(data);
        public override IApplyData __dataOut(QVoid data) => data;
        public static System.Threading.Tasks.Task<QVoid> Run(IOperationFactory __m__, Int64 x, Int64 modulus, Int64 power, QArray<Qubit> target)
        {
            return __m__.Run<ConstructU, (Int64,Int64,Int64,QArray<Qubit>), QVoid>((x, modulus, power, target));
        }
    }

    public class InverseFT : Unitary<QArray<Qubit>>, ICallable
    {
        public InverseFT(IOperationFactory m) : base(m)
        {
        }

        String ICallable.Name => "InverseFT";
        String ICallable.FullName => "myShorLib.InverseFT";
        protected IUnitary<Qubit> MicrosoftQuantumPrimitiveH
        {
            get;
            set;
        }

        protected IUnitary<(Int64,Int64,Qubit)> MicrosoftQuantumPrimitiveR1Frac
        {
            get;
            set;
        }

        protected IUnitary<(Qubit,Qubit)> MicrosoftQuantumPrimitiveSWAP
        {
            get;
            set;
        }

        public override Func<QArray<Qubit>, QVoid> Body => (__in) =>
        {
            var qs = __in;
#line 87 "C:\\AResource\\QuantumComputing\\myShor\\myShorLib\\Operation.qs"
            var qLength = qs.Count;
#line 88 "C:\\AResource\\QuantumComputing\\myShor\\myShorLib\\Operation.qs"
            foreach (var i in new Range(0L, (qLength - 1L)))
            {
#line 89 "C:\\AResource\\QuantumComputing\\myShor\\myShorLib\\Operation.qs"
                foreach (var j in new Range(0L, (i - 1L)))
                {
#line 90 "C:\\AResource\\QuantumComputing\\myShor\\myShorLib\\Operation.qs"
                    MicrosoftQuantumPrimitiveR1Frac.Controlled.Apply((new QArray<Qubit>()
                    {qs[j]}, (1L, (i - j), qs[i])));
                }

#line 92 "C:\\AResource\\QuantumComputing\\myShor\\myShorLib\\Operation.qs"
                MicrosoftQuantumPrimitiveH.Apply(qs[i]);
            }

#line 95 "C:\\AResource\\QuantumComputing\\myShor\\myShorLib\\Operation.qs"
            foreach (var i in new Range(0L, ((qLength / 2L) - 1L)))
            {
#line 96 "C:\\AResource\\QuantumComputing\\myShor\\myShorLib\\Operation.qs"
                MicrosoftQuantumPrimitiveSWAP.Apply((qs[i], qs[((qLength - 1L) - i)]));
            }

#line hidden
            return QVoid.Instance;
        }

        ;
        public override Func<QArray<Qubit>, QVoid> AdjointBody => (__in) =>
        {
            var qs = __in;
#line 87 "C:\\AResource\\QuantumComputing\\myShor\\myShorLib\\Operation.qs"
            var qLength = qs.Count;
            foreach (var i in new Range((0L - (((((qLength / 2L) - 1L) - 0L) / 1L) * -(1L))), -(1L), 0L))
            {
                MicrosoftQuantumPrimitiveSWAP.Adjoint.Apply((qs[i], qs[((qLength - 1L) - i)]));
            }

            foreach (var i in new Range((0L - ((((qLength - 1L) - 0L) / 1L) * -(1L))), -(1L), 0L))
            {
                MicrosoftQuantumPrimitiveH.Adjoint.Apply(qs[i]);
                foreach (var j in new Range((0L - ((((i - 1L) - 0L) / 1L) * -(1L))), -(1L), 0L))
                {
                    MicrosoftQuantumPrimitiveR1Frac.Controlled.Adjoint.Apply((new QArray<Qubit>()
                    {qs[j]}, (1L, (i - j), qs[i])));
                }
            }

#line hidden
            return QVoid.Instance;
        }

        ;
        public override Func<(QArray<Qubit>,QArray<Qubit>), QVoid> ControlledBody => (__in) =>
        {
            var (controlQubits,qs) = __in;
            var qLength = qs.Count;
            foreach (var i in new Range(0L, (qLength - 1L)))
            {
                foreach (var j in new Range(0L, (i - 1L)))
                {
                    MicrosoftQuantumPrimitiveR1Frac.Controlled.Controlled.Apply((controlQubits, (new QArray<Qubit>()
                    {qs[j]}, (1L, (i - j), qs[i]))));
                }

                MicrosoftQuantumPrimitiveH.Controlled.Apply((controlQubits, qs[i]));
            }

            foreach (var i in new Range(0L, ((qLength / 2L) - 1L)))
            {
                MicrosoftQuantumPrimitiveSWAP.Controlled.Apply((controlQubits, (qs[i], qs[((qLength - 1L) - i)])));
            }

#line hidden
            return QVoid.Instance;
        }

        ;
        public override Func<(QArray<Qubit>,QArray<Qubit>), QVoid> ControlledAdjointBody => (__in) =>
        {
            var (controlQubits,qs) = __in;
            var qLength = qs.Count;
            foreach (var i in new Range((0L - (((((qLength / 2L) - 1L) - 0L) / 1L) * -(1L))), -(1L), 0L))
            {
                MicrosoftQuantumPrimitiveSWAP.Adjoint.Controlled.Apply((controlQubits, (qs[i], qs[((qLength - 1L) - i)])));
            }

            foreach (var i in new Range((0L - ((((qLength - 1L) - 0L) / 1L) * -(1L))), -(1L), 0L))
            {
                MicrosoftQuantumPrimitiveH.Adjoint.Controlled.Apply((controlQubits, qs[i]));
                foreach (var j in new Range((0L - ((((i - 1L) - 0L) / 1L) * -(1L))), -(1L), 0L))
                {
                    MicrosoftQuantumPrimitiveR1Frac.Controlled.Adjoint.Controlled.Apply((controlQubits, (new QArray<Qubit>()
                    {qs[j]}, (1L, (i - j), qs[i]))));
                }
            }

#line hidden
            return QVoid.Instance;
        }

        ;
        public override void Init()
        {
            this.MicrosoftQuantumPrimitiveH = this.Factory.Get<IUnitary<Qubit>>(typeof(Microsoft.Quantum.Primitive.H));
            this.MicrosoftQuantumPrimitiveR1Frac = this.Factory.Get<IUnitary<(Int64,Int64,Qubit)>>(typeof(Microsoft.Quantum.Primitive.R1Frac));
            this.MicrosoftQuantumPrimitiveSWAP = this.Factory.Get<IUnitary<(Qubit,Qubit)>>(typeof(Microsoft.Quantum.Primitive.SWAP));
        }

        public override IApplyData __dataIn(QArray<Qubit> data) => data;
        public override IApplyData __dataOut(QVoid data) => data;
        public static System.Threading.Tasks.Task<QVoid> Run(IOperationFactory __m__, QArray<Qubit> qs)
        {
            return __m__.Run<InverseFT, QArray<Qubit>, QVoid>(qs);
        }
    }

    public class PowerMod : Operation<(Int64,Int64,Int64), Int64>, ICallable
    {
        public PowerMod(IOperationFactory m) : base(m)
        {
        }

        public class In : QTuple<(Int64,Int64,Int64)>, IApplyData
        {
            public In((Int64,Int64,Int64) data) : base(data)
            {
            }

            System.Collections.Generic.IEnumerable<Qubit> IApplyData.Qubits => null;
        }

        String ICallable.Name => "PowerMod";
        String ICallable.FullName => "myShorLib.PowerMod";
        protected ICallable<Int64, Int64> MicrosoftQuantumCanonBitSize
        {
            get;
            set;
        }

        public override Func<(Int64,Int64,Int64), Int64> Body => (__in) =>
        {
            var (x,power,modulus) = __in;
#line 110 "C:\\AResource\\QuantumComputing\\myShor\\myShorLib\\Operation.qs"
            var times = x;
#line 111 "C:\\AResource\\QuantumComputing\\myShor\\myShorLib\\Operation.qs"
            var result = 1L;
#line 112 "C:\\AResource\\QuantumComputing\\myShor\\myShorLib\\Operation.qs"
            var powerBits = power;
            // Fast Power
#line 115 "C:\\AResource\\QuantumComputing\\myShor\\myShorLib\\Operation.qs"
            var powerLength = MicrosoftQuantumCanonBitSize.Apply(power);
#line 116 "C:\\AResource\\QuantumComputing\\myShor\\myShorLib\\Operation.qs"
            foreach (var i in new Range(0L, (powerLength - 1L)))
            {
#line 117 "C:\\AResource\\QuantumComputing\\myShor\\myShorLib\\Operation.qs"
                if (((powerBits % 2L) == 1L))
                {
#line 118 "C:\\AResource\\QuantumComputing\\myShor\\myShorLib\\Operation.qs"
                    result = ((result * times) % modulus);
                }

#line 120 "C:\\AResource\\QuantumComputing\\myShor\\myShorLib\\Operation.qs"
                powerBits = (powerBits / 2L);
#line 121 "C:\\AResource\\QuantumComputing\\myShor\\myShorLib\\Operation.qs"
                times = ((times * times) % modulus);
            }

#line 123 "C:\\AResource\\QuantumComputing\\myShor\\myShorLib\\Operation.qs"
            return (result % modulus);
        }

        ;
        public override void Init()
        {
            this.MicrosoftQuantumCanonBitSize = this.Factory.Get<ICallable<Int64, Int64>>(typeof(Microsoft.Quantum.Canon.BitSize));
        }

        public override IApplyData __dataIn((Int64,Int64,Int64) data) => new In(data);
        public override IApplyData __dataOut(Int64 data) => new QTuple<Int64>(data);
        public static System.Threading.Tasks.Task<Int64> Run(IOperationFactory __m__, Int64 x, Int64 power, Int64 modulus)
        {
            return __m__.Run<PowerMod, (Int64,Int64,Int64), Int64>((x, power, modulus));
        }
    }

    public class MyTest : Operation<QVoid, Int64>, ICallable
    {
        public MyTest(IOperationFactory m) : base(m)
        {
        }

        String ICallable.Name => "MyTest";
        String ICallable.FullName => "myShorLib.MyTest";
        protected ICallable<(Int64,Int64,Int64), Int64> PhaseEstimation
        {
            get;
            set;
        }

        public override Func<QVoid, Int64> Body => (__in) =>
        {
#line 129 "C:\\AResource\\QuantumComputing\\myShor\\myShorLib\\Operation.qs"
            var a = PhaseEstimation.Apply((3L, 5L, 7L));
#line 130 "C:\\AResource\\QuantumComputing\\myShor\\myShorLib\\Operation.qs"
            return a;
        }

        ;
        public override void Init()
        {
            this.PhaseEstimation = this.Factory.Get<ICallable<(Int64,Int64,Int64), Int64>>(typeof(myShorLib.PhaseEstimation));
        }

        public override IApplyData __dataIn(QVoid data) => data;
        public override IApplyData __dataOut(Int64 data) => new QTuple<Int64>(data);
        public static System.Threading.Tasks.Task<Int64> Run(IOperationFactory __m__)
        {
            return __m__.Run<MyTest, QVoid, Int64>(QVoid.Instance);
        }
    }
}