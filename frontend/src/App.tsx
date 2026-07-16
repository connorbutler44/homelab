import "./App.css";
import { useContext, useState } from "react";
import { AuthorizationContext } from "./AuthorizationContext";

function App() {
  const [username, setUsername] = useState<string>("");
  const [password, setPassword] = useState<string>("");
  const auth = useContext(AuthorizationContext);

  return (
    <div>
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
        <button
          type="button"
          onClick={() => auth.performLogin(username, password)}
        >
          Login
        </button>
        <button type="button" onClick={() => auth.performLogout()}>
          Logout
        </button>
      </div>
      <div>
        {auth.isLoading ? "🟠" : auth.isLoggedIn ? "🟢" : "🔴"}
        {auth.isLoggedIn ? (
          <>Logged in as: {auth.user.username}</>
        ) : (
          <>Logged out</>
        )}
      </div>
    </div>
  );
}

export default App;
