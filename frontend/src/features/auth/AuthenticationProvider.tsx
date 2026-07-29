import { useEffect, useState, type PropsWithChildren } from "react";
import {
  AuthenticationContext,
  type AuthenticationState,
} from "./AuthenticationContext";
import { ApiRoutes } from "../../api/apiRoutes";
import { requestCsrfToken } from "../../api/csrf";
import { apiFetch } from "../../api/client";

export const AuthenticationProvider = (props: PropsWithChildren) => {
  const [authState, setAuthState] = useState<AuthenticationState>({
    isLoggedIn: false,
  });
  const [isLoading, setLoading] = useState<boolean>(true);

  const performLogin = async (username: string, password: string) => {
    console.log("Perform login start");
    setLoading(true);

    await apiFetch(ApiRoutes.Login, {
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
        console.log("Perform login success");
        if (res.ok) {
          performHeartbeatCheck();
        } else {
          setAuthState({ isLoggedIn: false });
          setLoading(false);
        }
      })
      .catch((error: unknown) => {
        console.log("Perform login fail", error);
        setLoading(false);
      });
  };

  const performLogout = async () => {
    setLoading(true);

    await apiFetch(ApiRoutes.Logout, {
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
    apiFetch(ApiRoutes.Me, {
      credentials: "include",
    })
      .then(async (res) => {
        if (res.ok) {
          setAuthState({
            isLoggedIn: true,
            user: await res.json(),
          });
          requestCsrfToken();
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
