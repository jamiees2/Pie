// <copyright file="ExtensionsTest.ForEach.g.cs" company="SuprDewd">Copyright � SuprDewd 2010</copyright>
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
using System.Collections.Generic;
using Microsoft.Pex.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Pex.Framework.Generated;
using Microsoft.Pex.Engine.Exceptions;

namespace SharpBag
{
    public partial class ExtensionsTest
    {
[TestMethod]
[PexGeneratedBy(typeof(ExtensionsTest))]
public void ForEach90801()
{
    int[] ints = new int[0];
    this.ForEach<int>
        ((IEnumerable<int>)ints, PexChoose.CreateDelegate<Action<int>>());
}
[TestMethod]
[PexGeneratedBy(typeof(ExtensionsTest))]
public void ForEach78801()
{
    int[] ints = new int[1];
    this.ForEach<int>
        ((IEnumerable<int>)ints, PexChoose.CreateDelegate<Action<int>>());
}
[TestMethod]
[PexGeneratedBy(typeof(ExtensionsTest))]
public void ForEach12501()
{
    int[] ints = new int[2];
    this.ForEach<int>
        ((IEnumerable<int>)ints, PexChoose.CreateDelegate<Action<int>>());
}
[TestMethod]
[PexGeneratedBy(typeof(ExtensionsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void ForEachThrowsContractException904()
{
    try
    {
      this.ForEach<int>((IEnumerable<int>)null, (Action<int>)null);
      throw 
        new AssertFailedException("expected an exception of type ContractException");
    }
    catch(Exception ex)
    {
      if (!PexContract.IsContractException(ex))
        throw ex;
    }
}
[TestMethod]
[PexGeneratedBy(typeof(ExtensionsTest))]
public void ForEach90802()
{
    int[] ints = new int[0];
    this.ForEach<int>
        ((IEnumerable<int>)ints, PexChoose.CreateDelegate<Action<int>>());
}
[TestMethod]
[PexGeneratedBy(typeof(ExtensionsTest))]
public void ForEach78802()
{
    int[] ints = new int[1];
    this.ForEach<int>
        ((IEnumerable<int>)ints, PexChoose.CreateDelegate<Action<int>>());
}
[TestMethod]
[PexGeneratedBy(typeof(ExtensionsTest))]
public void ForEach12502()
{
    int[] ints = new int[2];
    this.ForEach<int>
        ((IEnumerable<int>)ints, PexChoose.CreateDelegate<Action<int>>());
}
[TestMethod]
[PexGeneratedBy(typeof(ExtensionsTest))]
public void ForEach90803()
{
    int[] ints = new int[0];
    this.ForEach<int>
        ((IEnumerable<int>)ints, PexChoose.CreateDelegate<Action<int>>());
}
[TestMethod]
[PexGeneratedBy(typeof(ExtensionsTest))]
public void ForEach78803()
{
    int[] ints = new int[1];
    this.ForEach<int>
        ((IEnumerable<int>)ints, PexChoose.CreateDelegate<Action<int>>());
}
[TestMethod]
[PexGeneratedBy(typeof(ExtensionsTest))]
public void ForEach12503()
{
    int[] ints = new int[2];
    this.ForEach<int>
        ((IEnumerable<int>)ints, PexChoose.CreateDelegate<Action<int>>());
}
[TestMethod]
[PexGeneratedBy(typeof(ExtensionsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void ForEachThrowsContractException158()
{
    try
    {
      int[] ints = new int[0];
      this.ForEach<int>((IEnumerable<int>)ints, (Action<int>)null);
      throw 
        new AssertFailedException("expected an exception of type ContractException");
    }
    catch(Exception ex)
    {
      if (!PexContract.IsContractException(ex))
        throw ex;
    }
}
[TestMethod]
[PexGeneratedBy(typeof(ExtensionsTest))]
public void ForEach90804()
{
    int[] ints = new int[0];
    this.ForEach<int>
        ((IEnumerable<int>)ints, PexChoose.CreateDelegate<Action<int>>());
}
[TestMethod]
[PexGeneratedBy(typeof(ExtensionsTest))]
public void ForEach78804()
{
    int[] ints = new int[1];
    this.ForEach<int>
        ((IEnumerable<int>)ints, PexChoose.CreateDelegate<Action<int>>());
}
[TestMethod]
[PexGeneratedBy(typeof(ExtensionsTest))]
public void ForEach12504()
{
    int[] ints = new int[2];
    this.ForEach<int>
        ((IEnumerable<int>)ints, PexChoose.CreateDelegate<Action<int>>());
}
    }
}
