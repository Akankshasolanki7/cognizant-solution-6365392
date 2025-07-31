


## 🔀 23. Various Ways of Conditional Rendering in React

* `if/else` statement inside the render method
* Ternary operator: `{condition ? <A /> : <B />}`
* Logical `&&` operator: `{condition && <A />}`
* Immediately invoked function expression (IIFE) for complex logic

```jsx
{isLoggedIn && <Logout />}
{isAdmin ? <AdminPanel /> : <UserPanel />}
```

---

## 🧩 24. Rendering Multiple Components

* Wrap multiple components in a parent element like `div`, `React.Fragment`, or `<>`.

```jsx
return (
  <>
    <Header />
    <Content />
    <Footer />
  </>
);
```

---

## 📝 25. List Component

* Used to render a list of items using `.map()`

```jsx
function List(props) {
  return (
    <ul>
      {props.items.map(item => <li key={item.id}>{item.name}</li>)}
    </ul>
  );
}
```

---

## 🔑 26. Keys in React Applications

* `key` is a special prop used to uniquely identify elements in a list.
* Helps React optimize re-rendering.

```jsx
{items.map(item => <li key={item.id}>{item.name}</li>)}
```

---

## 🧱 27. Extract Components with Keys

* When mapping over data, extract each rendered element into a separate component and pass `key` at the parent level.

```jsx
function User(props) {
  return <li>{props.name}</li>;
}

{users.map(user => <User key={user.id} name={user.name} />)}
```

---

## 🗺️ 28. React Map / `map()` Function

* `map()` is a JavaScript function to loop over arrays.
* In React, it's often used to generate components dynamically.

```jsx
const names = ['Alice', 'Bob', 'Charlie'];
const nameList = names.map((name, index) => <li key={index}>{name}</li>);

return <ul>{nameList}</ul>;
```


