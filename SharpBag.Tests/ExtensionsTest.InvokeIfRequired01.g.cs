// <copyright file="ExtensionsTest.InvokeIfRequired01.g.cs" company="SuprDewd">Copyright � SuprDewd 2010</copyright>
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
using System.Windows.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Pex.Framework.Generated;
using Microsoft.Pex.Engine.Exceptions;

namespace SharpBag
{
    public partial class ExtensionsTest
    {
[TestMethod]
[PexGeneratedBy(typeof(ExtensionsTest))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void InvokeIfRequiredThrowsContractException870()
{
    try
    {
      this.InvokeIfRequired((DispatcherObject)null, (Action)null);
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
[PexRaisedContractException(PexExceptionState.Expected)]
public void InvokeIfRequired01ThrowsContractException382()
{
    try
    {
      this.InvokeIfRequired01
          ((DispatcherObject)null, (Action)null, DispatcherPriority.Inactive);
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
