## 🔄 React Component Lifecycle Objectives

This section focuses on understanding the **lifecycle** of a React component — what happens from creation to removal — and why it matters.

---

### ✅ Learning Objectives

- **Explain the Need and Benefits of Component Lifecycle**  
  React's component lifecycle helps you control how and when a component is created, updated, and destroyed. It allows developers to:
  - Perform actions at specific stages (e.g., fetch data after mount)
  - Optimize rendering and performance
  - Clean up resources like timers or subscriptions
  - Debug component behavior effectively

- **Identify Various Lifecycle Hook Methods**  
  React provides several lifecycle methods (for class components) and hooks (for function components) to manage different phases:
  
  **Class Components:**
  - `constructor()` – Initialization
  - `render()` – Rendering the UI
  - `componentDidMount()` – After component is added to the DOM
  - `componentDidUpdate()` – After updates
  - `componentWillUnmount()` – Before removal

  **Function Components (via Hooks):**
  - `useEffect()` – Acts like `componentDidMount`, `componentDidUpdate`, and `componentWillUnmount` combined depending on dependencies

- **List the Sequence of Steps in Rendering a Component**  
  Here is the typical sequence in **class components**:
  
  1. **constructor()** – Set initial state and bindings
  2. **render()** – Returns the JSX to render
  3. **componentDidMount()** – Called once the component is mounted
  4. **componentDidUpdate()** – Called after state or props change
  5. **componentWillUnmount()** – Cleanup before the component is removed

  In **function components**, `useEffect()` with appropriate dependencies handles these stages.

---

