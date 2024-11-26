## Table of Contents

1. [MultiThreading](#multithreading)  
2. [SemaphoreSlim](#semaphoreslim)
    1. [Constructor of the `SemaphoreSlim` Class in C#](#constructor-of-the-semaphoreslim-class-in-c)
       1. [Constructor: `SemaphoreSlim(int initialCount)`](#semaphoreslimint-initialcount)
       2. [Constructor: `SemaphoreSlim(int initialCount, int maximumCount)`](#semaphoreslimint-initialcount-int-maximumcount))
    2. [Methods of SemaphoreSlim Class in C#](#methods-of-semaphoreslim-class-in-c)
       1. [Method: `Wait()`](#wait)
       2. [Method: `Wait(TimeSpan timeout)`](#waittimespan-timeout))
       3. [Method: `Wait(CancellationToken cancellationToken)`](#waitcancellationtoken-cancellationtoken)
       4. [Method: `Wait(TimeSpan timeout, CancellationToken cancellationToken)`](#waittimespan-timeout-cancellationtoken-cancellationtoken)
       5. [Method: `Wait(int millisecondsTimeout)`](#waitint-millisecondstimeout)
       6. [Method: `Wait(int millisecondsTimeout, CancellationToken cancellationToken)`](#waitint-millisecondstimeout-cancellationtoken-cancellationtoken)
       7. [Method: `Release()`](#release)
       8. [Method: `Release(int releaseCount)`](#releaseint-releasecount)
    3. [Parameters of SemaphoreSlim Class in C#](#parameters)
       
---

## MultiThreading

### SemaphoreSlim

#### Why do we need SimaphoreSlim

- If we want more control over the number of internal threads that can access our applicaiton code.

#### <h3 style="color:red">Constructor of the `SemaphoreSlim` Class in C#<h3>

### `SemaphoreSlim(int initialCount)`

- **`initialCount`**: Specifies the initial number of requests for the semaphore that can be granted concurrently.

### `SemaphoreSlim(int initialCount, int maximumCount)`

- **`initialCount`**: Specifies the initial number of requests for the semaphore that can be granted concurrently.
- **`maxCount`**: Specifies the maximum number of requests for the semaphore that can be granted concurretly.

---

#### <h3 style="color:red">Methods of `SemaphoreSlim` Class in C#</h3>

## Wait Method

### `Wait()`

- Blocks the current thread until it can enter the System.Threading.SemaphoreSlim.

### `Wait(TimeSpan timeout)`

- Blocks the current thread until it can enter the SemaphoreSlim to specify the timeout.
- Returns true if the current thread successfully entered otherwise false.

### `Wait(CancellationToken cancellationToken)`

- Blocks the current thread until can enter the SemaphoreSlim while observing a CancellationToken.

### `Wait(TimeSpan timeout, CancellationToken cancellationToken)`

- Blocks current thread using a TimeSpan that specifies timeout, while observing a CancellationToken.
- Return true if successfully entered otherwise false.

### `Wait(int millisecondsTimeout)`

- Blocks the current thread, using a 32-bit signed integer that specifies the timeout.
- Returns true if successfully entered otherwise false.

### `Wait(int millisecondsTimeout, CancellationToken cancellationToken)`

- Blocks the current thread, using 32-bit signed integer that specifies timeout, while observing a CancellationToken.
- Returns true if successfully entered otherwise false.

#### Parameters

### `timeout`

- Represents the number of milliseconds to wait.
- -1 milliseconds to wait indefinitely

### `cancellationToken`

- System.Threading.CancellationToken to observe.

### `millisecondsTimeout`

- Number of milliseconds to wait. -1: infinitely and 0: return immediately.

## Release Method

### `Release()`

- Releases the SemaphoreSlim object once.
- Returns the previous count of the SemaphoreSlim.

### `Release(int releaseCount)`

- Releases the SemaphoreSlim object a specified number of times.
- **`releaseCount`** specifies the number of times to exit.