
## 🧩 16. React Events

* React handles events similar to HTML but with **camelCase** naming and **JSX syntax**.
* Events are passed as **functions**, not strings.

```jsx
<button onClick={() => alert('Clicked!')}>Click Me</button>
```

---

## 🛠️ 17. Event Handlers in React

* Event handlers are functions triggered on user interaction like click, hover, etc.
* Common handlers include `onClick`, `onChange`, `onSubmit`.

```jsx
function handleClick() {
  console.log("Button clicked");
}

<button onClick={handleClick}>Click</button>
```

---

## 🧵 18. Synthetic Events

* React wraps native events inside a **SyntheticEvent** to ensure cross-browser compatibility.
* SyntheticEvent works identically across all browsers.

```jsx
function handleInput(e) {
  console.log(e.target.value); // SyntheticEvent
}

<input onChange={handleInput} />
```

---

## 🧾 19. React Event Naming Convention

* Use **camelCase** for event names (e.g., `onClick`, `onChange`).
* Event handlers are passed as functions, **not strings**.

❌ Wrong:

```html
<button onclick="handleClick()">Click</button>
```

✅ Correct:

```jsx
<button onClick={handleClick}>Click</button>
```



