﻿namespace TestFramework;

public class Specification
{
    protected delegate void ParameterlessTestAction();

    protected static void Given(ParameterlessTestAction testAction)
    {
        testAction.Invoke();
    }

    protected static void And(ParameterlessTestAction testAction)
    {
        testAction.Invoke();
    }

    protected static void When(ParameterlessTestAction testAction)
    {
        testAction.Invoke();
    }

    protected static void Then(ParameterlessTestAction testAction)
    {
        testAction.Invoke();
    }
}