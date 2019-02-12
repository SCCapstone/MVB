using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

public class MVBTests
{

    [Test]
    public void QuitOnClick_Test()
    {
        bool QuitOnClick = false;
        bool value = QuitOnClick;

        Assert.That(value, Is.EqualTo(QuitOnClick));
    }
}
