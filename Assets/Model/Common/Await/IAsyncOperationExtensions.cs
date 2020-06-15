using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;

public static class IAsyncOperationExtensions
{
    public static AsyncOperationAwaiter<T> GetAwaiter<T>(this AsyncOperationHandle<T> handle) where T:UnityEngine.Object
    {
        return new AsyncOperationAwaiter<T>(handle);
    }
 }

public struct AsyncOperationAwaiter<T> : INotifyCompletion where T : UnityEngine.Object
{
    public AsyncOperationHandle<T> _operation;

    public AsyncOperationAwaiter(AsyncOperationHandle<T> operation)
    {
        _operation = operation;
    }

    public bool IsCompleted => _operation.Status != AsyncOperationStatus.None;

    public void OnCompleted(Action continuation) => _operation.Completed += (op) => continuation?.Invoke();

    public T GetResult() => _operation.Result;
}
