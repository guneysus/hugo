---
draft: true
---

Lets Build A Simple Calculator Interpreter
==========================================

```text
3+5
```
1. Token(INTEGER, 3)
2. Token(PLUS)
3. Token(INTEGER, 5)

```text
100.0 + 25 * 12.0 - 60.0
```

Tokenizer

1. Token(DECIMAL, 100.0)
2. WhiteSpace
3. Token(PLUS)
4. WhiteSpace
5. Token(INTEGER, 25)
6. WhiteSpace
7. Token(TIMES)
8. WhiteSpace
9. Token(DECIMAL, 12.0)
10. WhiteSpace
11. Token(MINUS)
12. WhiteSpace
13. Token(DECIMAL, 60.0)
14. WhiteSpace
15. Token(EOF)
   