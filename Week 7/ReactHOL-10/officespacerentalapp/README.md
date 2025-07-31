# ⚛️ 9. Define JSX
- JSX stands for **JavaScript XML**.
- It allows writing HTML-like syntax in JavaScript, mainly used in React.

```jsx
const element = <h1>Hello, JSX!</h1>;
```

---

## 🌍 10. Explain about ECMA Script
- ECMAScript (ES) is the **standard specification** that JavaScript follows.
- ES6, also known as ECMAScript 2015, introduced major enhancements like classes, arrow functions, promises, etc.

---

## 🔧 11. Explain `React.createElement()`
- A method to manually create a React element (used before JSX).

```js
React.createElement('h1', { className: 'greet' }, 'Hello World');
```

---

## 🏗️ 12. Create React nodes with JSX
- Use JSX to define UI elements like HTML tags:

```jsx
const heading = <h1>Welcome to React</h1>;
```

---

## 🖥️ 13. Render JSX to DOM
- Use `ReactDOM.render()` to render elements to the real DOM.

```jsx
ReactDOM.render(<App />, document.getElementById('root'));
```

---

## 🧮 14. JavaScript expressions in JSX
- You can embed JS expressions inside `{}`.

```jsx
const name = "Alice";
const greeting = <h1>Hello, {name}</h1>;
```

---

## 🎨 15. Inline CSS in JSX
- Pass style as a JS object with camelCase properties:

```jsx
const styleObj = {
  color: 'blue',
  fontSize: '20px'
};

const title = <h1 style={styleObj}>Styled Heading</h1>;
```

---
