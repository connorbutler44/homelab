import { useState } from "react";
import "./App.css";

function App() {
  const [username, setUsername] = useState<string>("");
  const [password, setPassword] = useState<string>("");

  const performLogin = async () => {
    await fetch("/login", {
      method: "POST",
      credentials: "include",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({
        Username: username,
        Password: password,
      }),
    }).then(console.log);
  };

  const performLogout = async () => {
    await fetch("/logout", {
      method: "POST",
      credentials: "include",
    }).then(console.log);
  };

  const performLoggedInTest = async () => {
    await fetch("/api/finance/test", {
      method: "POST",
      credentials: "include",
    }).then(console.log);
  };

  return (
    <div>
      <input
        type="text"
        value={username}
        onChange={(e) => setUsername(e.target.value)}
      />

      <input
        type="text"
        value={password}
        onChange={(e) => setPassword(e.target.value)}
      />
      <button type="button" onClick={performLogin}>
        Login
      </button>
      <button type="button" onClick={performLogout}>
        Logout
      </button>
      <button type="button" onClick={performLoggedInTest}>
        Logged In Test
      </button>
    </div>
  );
}

export default App;
