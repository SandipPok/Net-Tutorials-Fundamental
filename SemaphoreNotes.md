## Table of Contents

1. [MultiThreading](#multithreading)  
2. [Semaphore](#semaphore)
    1. [Constructor of the `Semaphore` Class in C#](#constructor-of-the-semaphore-class-in-c)
       1. [Constructor: `Semaphore(int initialCount, int maximumCount)`](#semaphoreint-initialcount-int-maximumcount)
       2. [Constructor: `Semaphore(int initialCount, int maximumCount, string name)`](#semaphoreint-initialcount-int-maximumcount-string-name)
       3. [Constructor: `Semaphore(int initialCount, int maximumCount, string name, out bool createdNew)`](#semaphoreint-initialcount-int-maximumcount-string-name-out-bool-creatednew)
       4. [Constructor: `Semaphore(int initialCount, int maximumCount, string name, out bool createdNew, SemaphoreSecurity semaphoreSecurity)`](#semaphoreint-initialcount-int-maximumcount-string-name-out-bool-creatednew-semaphoresecurity-semaphoresecurity)
    2. [Methods of Semaphore Class in C#](#methods-of-semaphore-class-in-c)
       1. [Method: `OpenExisting(string name)`](#openexistingstring-name)
       2. [Method: `OpenExisting(string name, SemaphoreRights rights)`](#openexistingstring-name-semaphorerights-rights)
       3. [Method: `TryOpenExisting(string name, out Semaphore result)`](#tryopenexistingstring-name-out-semaphore-result)
       4. [Method: `TryOpenExisting(string name, SemaphoreRights rights, out Semaphore result)`](#tryopenexistingstring-name-semaphorerights-rights-out-semaphore-result)
       5. [Method: `Release()`](#release)
       6. [Method: `Release(int releaseCount)`](#releaseint-releasecount)
       7. [Method: `GetAccessControl()`](#getaccesscontrol)
       8. [Method: `SetAccessControl(SemaphoreSecurity semaphoreSecurity)`](#setaccesscontrolsemaphoresecurity-semaphoresecurity)
       9. [Method: `WaitOne()`](#waitone)
       
---

## MultiThreading

### Semaphore

#### <h3 style="color:red">Constructor of the `Semaphore` Class in C#<h3>

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

---

#### <h3 style="color:red">Methods of Semaphore Class in C#<h3>

### `OpenExisting(string name)`

The `OpenExisting` method is used to open an existing named semaphore if it already exists. It returns an object that represents the specified system semaphore. The method has the following behavior:

- **Parameter**:
  - **`name`**: The name of the system semaphore to open. This is a string that identifies the semaphore in the system.

- **Exceptions**:
  - **`ArgumentException`**: This is thrown if the provided `name` is either an empty string (`""`) or exceeds 260 characters in length.
  - **`ArgumentNullException`**: This is thrown if the `name` is `null`.

#### Purpose:
- This method is useful when you need to access a pre-existing system semaphore by its name. It allows for synchronization between different processes or threads.

#### Example Usage:
```csharp
try
{
    string semaphoreName = "MyExistingSemaphore";
    Semaphore semaphore = Semaphore.OpenExisting(semaphoreName);
    Console.WriteLine("Semaphore opened successfully.");
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
catch (ArgumentNullException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
```

### Key Points:
1. **Usage**: `OpenExisting` is typically used when you want to interact with a semaphore that has already been created and named by another part of the system or application.
2. **Exceptions**: Proper handling of `ArgumentException` and `ArgumentNullException` is essential for ensuring that the method's parameters are valid.

---

### `OpenExisting(string name, SemaphoreRights rights)`

This method is used to open the specified named semaphore, if it already exists, with the desired security access.

- **Parameter**:
    - **`name`**: The name of the system semaphore to open. This is a string that identifies the semaphore in the system.
    - **`rights`**: This parameter rights specify a bitwise combination of the enumeration values that represent the desired security access.

#### Example Usage:
```csharp
Semaphore semaphore = Semaphore.OpenExisting("SemaphoreName", SemaphoreRights.Modify);
```

---

### `TryOpenExisting(string name, out Semaphore result)`

The method name suggests that it tries to open or access an existing resource (in this case, a `Semaphore`).

- **Parameter**:
    - **`name`**: This is an input parameter, which is the name of the existing Semaphore to be opened. The `name` would be a unique identifier for the `Semaphore`.
    - **`result`**: This is an output parameter (denoted by `out`). If the method successfully opens the existing `Semaphore`, it will assign it to the result variable. If it fails, result would be `null` (or a default value, depending on the implementation).

#### Purpose:

- The goal of this method is to try to open an existing `Semaphore` with the specified name.
- If the `Semaphore` exists and can be opened, it returns `true` and assigns the opened `Semaphore` object to the `result` variable. 
- If the `Semaphore` doesn't exist or some error occurs, the method would return `false` and result would be set to `null`.

#### Example Usage:
```csharp
using System;
using System.Threading;

class Program
{
    // Custom TryOpenExisting method
    public static bool TryOpenExisting(string name, out Semaphore result)
    {
        try
        {
            result = Semaphore.OpenExisting(name);
            return true; // Semaphore opened successfully
        }
        catch (System.IO.FileNotFoundException)
        {
            result = null; // Semaphore not found
            return false;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}"); // Handle other errors
            result = null;
            return false;
        }
    }

    static void Main()
    {
        string semaphoreName = "MySemaphore";

        // Try to open the existing Semaphore
        bool success = TryOpenExisting(semaphoreName, out Semaphore result);

        if (success && result != null)
        {
            Console.WriteLine("Successfully opened the existing Semaphore.");
        }
        else
        {
            Console.WriteLine("Failed to open the Semaphore.");
        }
    }
}

```

---

### `TryOpenExisting(string name, SemaphoreRights rights, out Semaphore result)`

This method is used to open the specified named Semaphore, if it already exists, with the desired security access, and returns a value that indicates whether the operation succeeded.

- **Parameter**:
    - **`name`**: The parameter `name` specifies the name of the system `Semaphore` to open.
    - **`rights`**: The parameter `rights` specify a bitwise combination of the enumeration values that represent the desired security access.
    - **`result`**: It will contain the reference to the opened Semaphore object if the operation succeeds.If the semaphore does not exist or if there is an issue with the operation (such as insufficient rights), `result` will be `null`.

#### Example Usage:

```csharp
using System;
using System.Threading;
using System.Security.AccessControl;

class Program
{
    public static bool TryOpenExisting(string name, SemaphoreRights rights, out Semaphore result)
    {
        try
        {
            // Assuming that the rights check is somehow applied when opening the semaphore
            // Semaphore.OpenExisting(name) itself does not take rights parameters, so you'd 
            // typically use AccessControl to manage rights externally.
            
            // Open the named semaphore (only for illustration, rights would be checked by OS)
            result = Semaphore.OpenExisting(name);
            
            // You'd check rights here, for example, by querying the access control list (ACL)
            // for the semaphore, though the .NET API does not directly support this
            // so this is a conceptual example.
            if (!HasRights(result, rights))
            {
                result = null; // If rights do not match
                return false;
            }

            return true; // Semaphore opened and rights are valid
        }
        catch (System.IO.FileNotFoundException)
        {
            result = null; // Semaphore not found
            return false;
        }
        catch (UnauthorizedAccessException)
        {
            result = null; // Access denied due to rights
            return false;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}"); // Handle other errors
            result = null;
            return false;
        }
    }

    private static bool HasRights(Semaphore semaphore, SemaphoreRights rights)
    {
        // In a real-world scenario, you would use AccessControl APIs to check if the 
        // specified rights are granted for the semaphore.
        // Here it's just a placeholder.
        return true; // Assume that rights are granted (for simplicity)
    }

    static void Main()
    {
        string semaphoreName = "MySemaphore";
        SemaphoreRights rights = SemaphoreRights.Synchronize | SemaphoreRights.Modify;

        // Try to open the existing Semaphore
        bool success = TryOpenExisting(semaphoreName, rights, out Semaphore result);

        if (success && result != null)
        {
            Console.WriteLine("Successfully opened the existing Semaphore with the right permissions.");
        }
        else
        {
            Console.WriteLine("Failed to open the Semaphore.");
        }
    }
}

```

---

### `Release()`

This method exit the semaphore and returns the previous count.

#### Example Usage:

```csharp
semaphore.Release();
```

---

### `Release(int releaseCount)`

This method exit the semaphore a specified number of times and returns the previous count.

- **Parameter**:
    - **`releaseCount`**: It represents the number of threads to release from the semaphore.

#### Example Usage:

```csharp
semaphore.Release(2);
```

---

### `GetAccessControl()`

This method Gets the access control security for a named system semaphore.

#### Example Usage:

```csharp
// Get the security information of the semaphore
SemaphoreSecurity semaphoreSecurity = semaphore.GetAccessControl();

```

---

### `SetAccessControl(SemaphoreSecurity semaphoreSecurity)`

This method Sets the access control security for a named system semaphore.

- **Parameter**:
    - **`semaphoreSecurity`**: This parameter expects an instance of the SemaphoreSecurity class, which is used to define the access rules.

#### Example Usage:

```csharp
public static void Main()
    {
        // Create a new SemaphoreSecurity object
        SemaphoreSecurity semaphoreSecurity = new SemaphoreSecurity();

        // Define an access rule that grants the current user full control over the semaphore
        var currentUser = WindowsIdentity.GetCurrent();
        SemaphoreAccessRule accessRule = new SemaphoreAccessRule(
            currentUser.Name, 
            SemaphoreRights.FullControl, 
            AccessControlType.Allow);

        // Add the access rule to the SemaphoreSecurity object
        semaphoreSecurity.AddAccessRule(accessRule);

        // Create or open the named semaphore
        Semaphore semaphore = new Semaphore(1, 1, "MySemaphore");

        // Set the access control rules for the semaphore
        semaphore.SetAccessControl(semaphoreSecurity);

        // Now you can use the semaphore with the specified security settings
        Console.WriteLine("Access control set on the semaphore.");
    }
```

---

### `WaitOne()`

Threads can enter into the critical section by using the WaitOne method.

#### Example Usage:

```csharp
private static Semaphore semaphore = new Semaphore(2, 2); // Initialize with max 2 threads

semaphore.WaitOne();
```