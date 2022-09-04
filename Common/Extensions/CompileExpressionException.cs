using System;
using System.Runtime.Serialization;

[Serializable]
public class CompileExpressionException : Exception
{
    private string expression;
    private object activeObject;

    public CompileExpressionException()
    {
    }

    public CompileExpressionException(string message) : base(message)
    {
    }

    public CompileExpressionException(string expression, object activeObject)
    {
        this.expression = expression;
        this.activeObject = activeObject;
    }

    public CompileExpressionException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected CompileExpressionException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}