---
draft: true
---
clean and performant code dog food
==================================

DO NOT DO THIS for methods that called repeatedly
```csharp
IEnumerable enumerable = (IEnumerable)ToList.MakeGenericMethod(source.ElementType).Invoke(null, new object[] { source });
```

INSTEAD, create a delegate for method than call this delegate.

```csharp
Delegate toList = Delegate.CreateDelegate(typeof(Func<List<T>>), this, (IEnumerable)ToList.MakeGenericMethod(source.ElementType));
```