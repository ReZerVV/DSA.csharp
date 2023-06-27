<h3> List types: </h3>

- Singly linked linear list
- Singly linked circular list
- Doubly linked linear list
- Doubly linked circular list

<h3> Structure singly linked linear list: </h3>

```
NODE 1           NODE 2           NODE 3
+----------+     +----------+     +----------+
|Value     |     |Value     |     |Value     | 
|Next      | --> |Next      | --> |Next      | --> null
+----------+     +----------+     +----------+
```

<h3> Structure singly linked circular list: </h3>

```
NODE 1           NODE 2           NODE 3
+----------+     +----------+     +----------+
|Value     |     |Value     |     |Value     | 
|Next      | --> |Next      | --> |Next      | --> NODE 1
+----------+     +----------+     +----------+
```

<h3> Structure doubly linked linear list: </h3>

```
          NODE 1           NODE 2           NODE 3
          +----------+     +----------+     +----------+
          |Value     |     |Value     |     |Value     |
null  <-- |Prev      | <-- |Prev      | <-- |Prev      |
          |Next      | --> |Next      | --> |Next      | --> null
          +----------+     +----------+     +----------+
```

<h3> Structure doubly linked circular list: </h3>

```
            NODE 1           NODE 2           NODE 3
            +----------+     +----------+     +----------+
            |Value     |     |Value     |     |Value     |
NODE 3  <-- |Prev      | <-- |Prev      | <-- |Prev      |
            |Next      | --> |Next      | --> |Next      | --> NODE 1
            +----------+     +----------+     +----------+
```
