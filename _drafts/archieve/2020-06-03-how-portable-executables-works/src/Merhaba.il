.assembly extern mscorlib
{
    .ver 4:0:0:0
    .publickeytoken = (B7 7A 5C 56 19 34 E0 89)
}

.assembly Merhaba {}

.method private hidebysig static void Main() cil managed
{
    .entrypoint
    .maxstack  1
    ldstr      "Merhaba" 
    call void [mscorlib]System.Console::WriteLine(string)
    ret
}