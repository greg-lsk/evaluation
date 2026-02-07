using View;


namespace Evaluation;

public delegate bool Check();
public delegate Task<bool> CheckAsync();
public delegate ValueTask<bool> CheckMaybeAsync();

public delegate bool Check<T>(T data) where T : class;
public delegate Task<bool> CheckAsync<T>(T data) where T : class;
public delegate ValueTask<bool> CheckMaybeAsync<T>(T data) where T : class;

public delegate bool CheckOnStruct<T>(in T data) where T : struct;
public delegate Task<bool> CheckOnStructAsync<T>(T data) where T : struct;
public delegate ValueTask<bool> CheckOnStructMaybeAsync<T>(T data) where T : struct;

public delegate bool CheckOnView<T>(View<T> data) where T : struct;
public delegate Task<bool> CheckOnViewAsync<T>(View<T> data) where T : struct;
public delegate ValueTask<bool> CheckOnViewMaybeAsync<T>(View<T> data) where T : struct;