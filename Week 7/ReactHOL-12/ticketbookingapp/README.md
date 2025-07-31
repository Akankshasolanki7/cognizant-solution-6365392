
## 🌓 20. Conditional Rendering in React

* Render different elements based on conditions using `if`, ternary, or logical `&&`.

```jsx
{isLoggedIn ? <Logout /> : <Login />}
```

---

## 🧱 21. Element Variables

* Use variables to store JSX elements before returning them.

```jsx
let button;
if (isLoggedIn) {
  button = <LogoutButton />;
} else {
  button = <LoginButton />;
}

return <div>{button}</div>;
```

---

## 🚫 22. Prevent Component from Rendering

* Return `null` to prevent a component from rendering.

```jsx
function WarningBanner(props) {
  if (!props.warn) {
    return null;
  }
  return <div className="warning">Warning!</div>;
}
```


