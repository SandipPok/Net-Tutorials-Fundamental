## Table of Contents

1. [MultiThreading](#multithreading)  
2. [Semaphore](#semaphore)
   1. [Constructor of the `Semaphore` Class in C#](#constructor-of-the-semaphore-class-in-c)
   2. [Constructor: `Semaphore(int initialCount, int maximumCount, string name)`](#semaphoreint-initialcount-int-maximumcount-string-name)
   3. [Constructor: `Semaphore(int initialCount, int maximumCount, string name, out bool createdNew)`](#semaphoreint-initialcount-int-maximumcount-string-name-out-bool-creatednew)
   4. [Constructor: `Semaphore(int initialCount, int maximumCount, string name, out bool createdNew, SemaphoreSecurity semaphoreSecurity)`](#semaphoreint-initialcount-int-maximumcount-string-name-out-bool-creatednew-semaphoresecurity-semaphoresecurity)


---

## MultiThreading

### Semaphore

#### Constructor of the `Semaphore` Class in C#

### `Semaphore(int initialCount, int maximumCount)`

This constructor initializes a new instance of the `Semaphore` class with the following parameters:

- **`initialCount`**: The initial number of available permits. This determines how many threads can concurrently access the critical section or shared resource when the semaphore is first created.
  
- **`maximumCount`**: The maximum number of permits that the semaphore can hold. This defines the upper limit on the number of threads that can access the critical section at the same time.

#### Purpose:
- The **`initialCount`** specifies how many threads can enter the critical section initially. If set to a positive value, that many threads can acquire the semaphore right away.
- The **`maximumCount`** sets the upper limit for concurrent access to the resource. It restricts how many threads can simultaneously hold a permit, preventing too many threads from entering the critical section at once.

#### Example Usage:
```csharp
Semaphore semaphore = new Semaphore(2, 5);
```

---


### `Semaphore(int initialCount, int maximumCount, string name)`

This constructor initializes a new instance of the `Semaphore` class with the following parameters:

- **`initialCount`**: Specifies the initial number of available permits.
- **`maximumCount`**: Defines the maximum number of permits (concurrent entries).
- **`name`**: Optionally specifies the name of the system semaphore object.

#### Purpose:
- The **`initialCount`** specifies the initial number of permits available when the semaphore is created.
- The **`maximumCount`** sets the upper limit on the number of threads that can acquire a permit simultaneously.
- The **`name`** allows you to give the semaphore a system-wide name, useful for inter-process synchronization.

#### Example Usage:
```csharp
Semaphore semaphore = new Semaphore(2, 5, "MySemaphore");
```

---

### `Semaphore(int initialCount, int maximumCount, string name, out bool createdNew)`

This constructor initializes a new instance of the `Semaphore` class with the possibility of creating a new system semaphore.

- **Parameters**:
  - **`initialCount`**: The initial number of available permits. This specifies how many threads can initially enter the critical section or resource.
  - **`maximumCount`**: The maximum number of concurrent permits. It determines the upper limit on the number of threads that can access the critical section simultaneously.
  - **`name`**: Optionally specifies the name of the system semaphore object. This allows you to create or open a semaphore with a specific name.
  - **`createdNew`**: An output variable that indicates whether a new system semaphore was created (`true` if created, `false` if an existing semaphore was opened).

#### Purpose:
- The **`createdNew`** output parameter indicates whether a new system semaphore was created (`true`) or if an existing semaphore with the given name was opened (`false`).
- This constructor allows you to create or open a named system semaphore and check whether it is new or already existing.

#### Example Usage:
```csharp
bool createdNew;
Semaphore semaphore = new Semaphore(2, 5, "MySemaphore", out createdNew);

if (createdNew)
{
    Console.WriteLine("A new semaphore was created.");
}
else
{
    Console.WriteLine("An existing semaphore was opened.");
}
```

---

### `Semaphore(int initialCount, int maximumCount, string name, out bool createdNew, SemaphoreSecurity semaphoreSecurity)`

This constructor initializes a new instance of the `Semaphore` class with security settings.

- **Parameters**:
  - **`initialCount`**: The initial number of available permits. This specifies how many threads can initially access the critical section or shared resource.
  - **`maximumCount`**: The maximum number of concurrent permits. This limits the number of threads that can access the critical section simultaneously.
  - **`name`**: Optionally specifies the name of the system semaphore object. This allows you to create or open a semaphore with a specific name.
  - **`createdNew`**: An output variable that indicates whether a new system semaphore was created (`true`) or if an existing semaphore was opened (`false`).
  - **`semaphoreSecurity`**: Specifies the security access control for the system semaphore. This controls who has permission to access the semaphore.

#### Purpose:
- The **`createdNew`** output variable lets you determine whether the semaphore is newly created or if an existing semaphore was used.
- The **`semaphoreSecurity`** parameter provides access control settings for the system semaphore, allowing you to define who can access it based on security permissions. This is useful when you need to ensure only authorized users or processes can interact with the semaphore.

#### Example Usage:
```csharp
SemaphoreSecurity security = new SemaphoreSecurity();
// Configure security settings as needed (e.g., granting permissions).
bool createdNew;
Semaphore semaphore = new Semaphore(2, 5, "MySecureSemaphore", out createdNew, security);

if (createdNew)
{
    Console.WriteLine("A new secure semaphore was created.");
}
else
{
    Console.WriteLine("An existing secure semaphore was opened.");
}
```
