# ES6 JavaScript – Objective Notes

## 📃 Objectives

* List the features of ES6
* Explain JavaScript `let`
* Identify the differences between `var` and `let`
* Explain JavaScript `const`
* Explain ES6 class fundamentals
* Explain ES6 class inheritance
* Define ES6 arrow functions
* Identify `set()` and `map()`

---

## ✅ 1. Features of ES6

* `let` and `const` for block-scoped variables
* Arrow functions (`=>`)
* Classes and inheritance
* Template literals using backticks `` `Hello ${name}` ``
* Default and rest parameters
* Destructuring arrays and objects
* Spread operator `...`
* Promises for async code
* `Map` and `Set` objects
* `for...of` loop
* Modules (import/export)

---

## 🔹 2. JavaScript `let`

* `let` declares **block-scoped** variables.
* Cannot be redeclared in the same scope.
* Not hoisted like `var`.

```js
let a = 10;
if (true) {
  let a = 20; // different variable
  console.log(a); // 20
}
console.log(a); // 10
```

---

## 🔁 3. Difference Between `var` and `let`

| Feature       | `var`                          | `let`                 |
| ------------- | ------------------------------ | --------------------- |
| Scope         | Function-scoped                | Block-scoped          |
| Hoisting      | Yes (initialized as undefined) | Yes (not initialized) |
| Redeclaration | Allowed                        | Not allowed           |

---

## 🔒 4. JavaScript `const`

* Used to declare **constants** (block-scoped).
* Value can't be reassigned, but **object properties can change**.

```js
const x = 5;
// x = 10; // ❌ Error

const user = { name: "Alex" };
user.name = "Bob"; // ✅ Allowed
```

---

## 🧱 5. ES6 Class Fundamentals

* ES6 classes are syntactic sugar over constructor functions.
* Use `constructor()` for initializing objects.

```js
class Person {
  constructor(name) {
    this.name = name;
  }

  greet() {
    return `Hello, ${this.name}`;
  }
}
```

---

## 👨‍👩‍👦 6. ES6 Class Inheritance

* Use `extends` and `super()` to inherit from another class.

```js
class Student extends Person {
  constructor(name, grade) {
    super(name); // calls Person constructor
    this.grade = grade;
  }

  info() {
    return `${this.name} is in grade ${this.grade}`;
  }
}
```

---

## ➡️ 7. Arrow Functions in ES6

* Shorter syntax for functions.
* Does **not bind its own `this`**.

```js
const add = (a, b) => a + b;
const greet = () => console.log("Hello");
```

---

## 🗃️ 8. `Set()` and `Map()` in ES6

### ✅ `Set`

* Stores **unique** values only.

```js
const s = new Set([1, 2, 2, 3]);
s.add(4);
console.log(s); // Set(4) {1, 2, 3, 4}
```

### ✅ `Map`

* Stores **key-value pairs**.
* Keys can be of **any type**.

```js
const m = new Map();
m.set("name", "Alice");
m.set(1, "one");

console.log(m.get("name")); // Alice
```


```
