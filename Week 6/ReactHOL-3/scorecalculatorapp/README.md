## 🎯 React Component Objectives

This section outlines the key concepts and objectives related to React components.

---

### ✅ Learning Objectives

- **Explain React Components**  
  Understand that React components are the building blocks of a React application. They allow you to split the UI into independent, reusable pieces that can be handled separately.

- **Identify the Differences Between Components and JavaScript Functions**  
  While both can accept inputs and return outputs, React components return JSX and are used to render UI. Regular JavaScript functions don't handle UI rendering or lifecycle methods.

- **Identify the Types of Components**  
  React offers two main types of components:
  - **Class Components**
  - **Function Components**  
  Each has its own syntax and capabilities, with functional components being more modern and often preferred.

- **Explain Class Component**  
  A class component is an ES6 class that extends `React.Component` and requires a `render()` method. It can hold local state and use lifecycle methods like `componentDidMount()`.

- **Explain Function Component**  
  A function component is a simpler way to write components using JavaScript functions. With the introduction of React Hooks (e.g., `useState`, `useEffect`), function components can now manage state and side effects.

- **Define Component Constructor**  
  In class components, the `constructor()` method is used to initialize state and bind methods. It is called before the component is mounted.

- **Define render() Function**  
  The `render()` method is mandatory in class components. It returns JSX which tells React what to display on the UI.

---

