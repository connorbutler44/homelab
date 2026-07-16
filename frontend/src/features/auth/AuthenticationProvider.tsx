import { useEffect, useState, type PropsWithChildren } from "react";
import {
  AuthenticationContext,
  type AuthenticationState,
} from "./AuthenticationContext";

export const AuthenticationProvider = (props: PropsWithChildren) => {
  const [authState, setAuthState] = useState<AuthenticationState>({
    isLoggedIn: false,
  });
  const [isLoading, setLoading] = useState<boolean>(true);

  const performLogin = async (username: string, password: string) => {
    setLoading(true);

    await fetch("/auth/login", {
      method: "POST",
      credentials: "include",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({
        Username: username,
        Password: password,
      }),
    })
      .then((res) => {
        if (res.ok) {
          performHeartbeatCheck();
        } else {
          setAuthState({ isLoggedIn: false });
          setLoading(false);
        }
      })
      .catch(() => {
        setLoading(false);
      });
  };

  const performLogout = async () => {
    setLoading(true);

    await fetch("/auth/logout", {
      method: "POST",
      credentials: "include",
    })
      .then((res) => {
        if (res.ok) {
          setAuthState({ isLoggedIn: false });
        }
      })
      .finally(() => setLoading(false));
  };

  const performHeartbeatCheck = () => {
    fetch("/auth/me", {
      credentials: "include",
    })
      .then(async (res) => {
        console.log(res);
        if (res.ok) {
          setAuthState({
            isLoggedIn: true,
            user: await res.json(),
          });
        } else {
          setAuthState({ isLoggedIn: false });
        }
      })
      .finally(() => setLoading(false));
  };

  useEffect(() => {
    performHeartbeatCheck();
  }, []);

  return (
    <AuthenticationContext.Provider
      value={{
        ...authState,
        isLoading,
        performLogin,
        performLogout,
      }}
    >
      {props.children}
    </AuthenticationContext.Provider>
  );
};
