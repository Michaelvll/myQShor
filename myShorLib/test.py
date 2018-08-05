#!/usr/bin/env python
# -*- coding: utf-8 -*-

import qsharp
from qsharp.tomography import single_qubit_process_tomography

import sys
sys.path.append('./bin/Debug/netstandard2.0')
import clr

clr.AddReference("Microsoft.Quantum.Canon")
clr.AddReference('myShorLib')
# print(SWF)

from myShorLib import (
    PhaseEstimation
)

qsim = qsharp.QuantumSimulator()

s = qsim.run(PhaseEstimation, 3, 5).result()

a = int(s.clr_object)
print(a+10)
