##Make From Base

This will tell the compiler / runtime to make an derived implementation based on the base class.

`make ` informs the compiler to replace the `@` reference with the Derived type.

```
abstract class base

  make shared function CreateNew() as @base
    return new @base()
  end function
  
end class
```

```
class Derived
  inherits base
 
  shared function CreateNew() as Derived
    return new Derived()
  end function
  
end class
```
