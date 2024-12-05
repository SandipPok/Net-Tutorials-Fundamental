## MultiThreading

### Thread Terminate

#### Method to terminate thread

| Method | Description |
| -- | -- |
| **`Abort()`** | Throw ThreadStateException if thread is suspended. |
| **`Abort(object stateInfo)`** | `stateInfo`: Specifies an object that contains application-specific information |

**`Note`**: `Abort()` and `Abort(object stateInfo)` method is not supported in .NET Core or .NET 5+ and should be avoided 