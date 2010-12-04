// <copyright file="PriorityQueueTTest.Peek.g.cs" company="SuprDewd">Copyright � SuprDewd 2010</copyright>
// <auto-generated>
// This file contains automatically generated unit tests.
// Do NOT modify this file manually.
// 
// When Pex is invoked again,
// it might remove or update any previously generated unit tests.
// 
// If the contents of this file becomes outdated, e.g. if it does not
// compile anymore, you may delete this file and invoke Pex again.
// </auto-generated>
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Pex.Framework.Generated;
using System.Collections.Generic;
using Microsoft.Pex.Framework.Explorable;
using Microsoft.Pex.Engine.Exceptions;
using Microsoft.ExtendedReflection.DataAccess;

namespace SharpBag.Algorithms
{
    public partial class PriorityQueueTTest
    {
[TestMethod]
[PexGeneratedBy(typeof(PriorityQueueTTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void PeekThrowsContractException550()
{
    try
    {
      PriorityQueue<int> priorityQueue;
      int i;
      priorityQueue = new PriorityQueue<int>();
      i = this.Peek<int>(priorityQueue);
      throw 
        new AssertFailedException("expected an exception of type ContractException");
    }
    catch(Exception ex)
    {
      if (!PexContract.IsContractException(ex))
        throw ex;
    }
}
    }
}
